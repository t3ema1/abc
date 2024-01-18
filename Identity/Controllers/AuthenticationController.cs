using Azure;
using Identity.Models;
using Identity.Models.Announcement_data;
using Identity.Models.Login;
using Identity.Models.Meeting_data;
using Identity.Models.NTAstory_data;
using Identity.Models.published_data;
using Identity.Models.SignUp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {


        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;




        public AuthenticationController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
            Console.WriteLine("Hello World!1");



        }
        [HttpPost]

        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser)
        {
            Console.WriteLine("Hello World!2");


            string role = registerUser.role;


            var userExist = await _userManager.FindByEmailAsync(registerUser.Email);
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }


            IdentityUser user = new()
            {
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUser.Username,


            };
            if (await _roleManager.RoleExistsAsync(role))
            {
                var result = await _userManager.CreateAsync(user, registerUser.Password);

                await _userManager.AddToRoleAsync(user, role);


                if (result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status201Created);

                }
                else return StatusCode(StatusCodes.Status500InternalServerError);
            }
            else return StatusCode(StatusCodes.Status502BadGateway);
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }


                var jwtToken = GetToken(authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    expiration = jwtToken.ValidTo
                });
                //returning the token...

            }
            return Unauthorized();




        }


        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(2),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        [HttpGet("users")]
       
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var userViewModels = users.Select(user => new
            {
                Username = user.UserName,
                Roles = _userManager.GetRolesAsync(user).Result
            });

            return Ok(userViewModels);
        }



        [HttpDelete("deleteAllUsers")]
        public IActionResult DeleteAllUsers()
        {
            try
            {
                // Get all users
                var allUsers = _context.Users.ToList();

                // Remove each user from the context
                foreach (var user in allUsers)
                {
                    _context.Users.Remove(user);
                }

                // Save changes to the database
                _context.SaveChanges();

                return Ok("All users deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }




        [HttpPost("addannouncement")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAnnouncement([FromBody] Announcement announcement)
        {
            try
            {
                var newAnnouncement = new Announcement
                {
                    LabelName = announcement.LabelName,
                    MessageBody = announcement.MessageBody,
                    PublishedTo = announcement.PublishedTo,
                    AnnouncementDate = announcement.AnnouncementDate,
                    Createdby = User.Identity.Name
                };
                _context.Announcements.Add(newAnnouncement);
                await _context.SaveChangesAsync();


                switch (announcement.PublishedTo)
                {

                    case 1:
                        var adminAnnouncement = new AdminAnnouncement
                        {
                            AnnouncementId = newAnnouncement.Id,
                            LabelName = announcement.LabelName,
                            MessageBody = announcement.MessageBody,
                            PublishedTo = announcement.PublishedTo,
                            AnnouncementDate = announcement.AnnouncementDate,
                            Createdby = User.Identity.Name
                        };
                        _context.AdminAnnouncements.Add(adminAnnouncement);
                        

                        break;

                    case 2:
                        var hrAnnouncement = new HrAnnouncement
                        {
                            AnnouncementId = newAnnouncement.Id,
                            LabelName = announcement.LabelName,
                            MessageBody = announcement.MessageBody,
                            PublishedTo = announcement.PublishedTo,
                            AnnouncementDate = announcement.AnnouncementDate,
                            Createdby = User.Identity.Name
                        };
                        _context.HrAnnouncements.Add(hrAnnouncement);
                       
                        break;

                    case 3:
                        var employeeAnnouncement = new EmployeeAnnouncement
                        {   
                            AnnouncementId = newAnnouncement.Id,
                            LabelName = announcement.LabelName,
                            MessageBody = announcement.MessageBody,
                            PublishedTo = announcement.PublishedTo,
                            AnnouncementDate = announcement.AnnouncementDate,
                            Createdby = User.Identity.Name
                        };
                        _context.EmployeeAnnouncements.Add(employeeAnnouncement);


                        break;

                    default:
                        return BadRequest("Invalid PublishedTo value.");
                }

                

                await _context.SaveChangesAsync();
                var announcementHistory = new AnnouncementHistory
                {
                    AnnouncementId = newAnnouncement.Id, 
                    CreatedBy = User.Identity.Name,
                    LabelName = announcement.LabelName,
                    CreationDate = announcement.AnnouncementDate, 
                    LastUpdatedDate = announcement.AnnouncementDate,
                    LastUpdatedBy = User.Identity.Name
                };
                _context.AnnouncementsHistory.Add(announcementHistory);
                await _context.SaveChangesAsync();


                return Ok(new { message = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding announcement.");
            }
        }

        [HttpGet("adminAnnouncements")]
        public IActionResult GetAdminAnnouncements()
        {
            var adminAnnouncements = _context.AdminAnnouncements.ToList();
            return Ok(adminAnnouncements);
        }

        [HttpGet("hrAnnouncements")]
        public IActionResult GetHrAnnouncements()
        {
            var hrAnnouncements = _context.HrAnnouncements.ToList();
            return Ok(hrAnnouncements);
        }

        [HttpGet("employeeAnnouncements")]
        public IActionResult GetEmployeeAnnouncements()
        {
            var employeeAnnouncements = _context.EmployeeAnnouncements.ToList();
            return Ok(employeeAnnouncements);
        }

        [HttpGet("allAnnouncements")]
        //[Authorize(Roles = "Admin")]
        public IActionResult GetAllAnnouncements()
        {
            var allAnnouncements = _context.Announcements.ToList();
            return Ok(allAnnouncements);
        }



        [HttpGet("announcementhistory")]
        public IActionResult GetAnnouncementHistory()
        {
            try
            {
                var announcementHistory = _context.AnnouncementsHistory.ToList();
                return Ok(announcementHistory);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving announcement history.");
            }
        }



        [HttpPut("updateannouncement/{announcementId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAnnouncement(int announcementId, [FromBody] Announcement updatedAnnouncement)
        {
            try
            {
                var existingAnnouncement = await _context.Announcements.FindAsync(announcementId);

                if (existingAnnouncement == null)
                {
                    return NotFound("Announcement not found.");
                }

                int originalPublishedTo = existingAnnouncement.PublishedTo;

                existingAnnouncement.LabelName = updatedAnnouncement.LabelName;
                existingAnnouncement.MessageBody = updatedAnnouncement.MessageBody;
                existingAnnouncement.AnnouncementDate = updatedAnnouncement.AnnouncementDate;

                _context.Announcements.Update(existingAnnouncement);
                await _context.SaveChangesAsync();

                switch (originalPublishedTo)
                {
                    case 1:
                        var adminAnnouncement = await _context.AdminAnnouncements.FirstOrDefaultAsync(a => a.AnnouncementId == announcementId);
                        if (adminAnnouncement != null)
                        {
                            adminAnnouncement.LabelName = updatedAnnouncement.LabelName;
                            adminAnnouncement.MessageBody = updatedAnnouncement.MessageBody;
                            adminAnnouncement.AnnouncementDate = updatedAnnouncement.AnnouncementDate;
                            _context.AdminAnnouncements.Update(adminAnnouncement);
                        }
                        break;

                    case 2:
                        var hrAnnouncement = await _context.HrAnnouncements.FirstOrDefaultAsync(a => a.AnnouncementId == announcementId);
                        if (hrAnnouncement != null)
                        {
                            hrAnnouncement.LabelName = updatedAnnouncement.LabelName;
                            hrAnnouncement.MessageBody = updatedAnnouncement.MessageBody;
                            hrAnnouncement.AnnouncementDate = updatedAnnouncement.AnnouncementDate;
                            _context.HrAnnouncements.Update(hrAnnouncement);
                        }
                        break;

                    case 3:
                        var employeeAnnouncement = await _context.EmployeeAnnouncements.FirstOrDefaultAsync(a => a.AnnouncementId == announcementId);
                        if (employeeAnnouncement != null)
                        {
                            employeeAnnouncement.LabelName = updatedAnnouncement.LabelName;
                            employeeAnnouncement.MessageBody = updatedAnnouncement.MessageBody;
                            employeeAnnouncement.AnnouncementDate = updatedAnnouncement.AnnouncementDate;
                            _context.EmployeeAnnouncements.Update(employeeAnnouncement);
                        }
                        break;

                    default:
                        return BadRequest("Invalid PublishedTo value.");
                }

                var announcementHistory = await _context.AnnouncementsHistory
                    .FirstOrDefaultAsync(a => a.AnnouncementId == announcementId);

                if (announcementHistory != null)
                {
                    announcementHistory.LastUpdatedBy = User.Identity.Name;
                    announcementHistory.LastUpdatedDate = DateTime.UtcNow;
                    announcementHistory.LabelName = updatedAnnouncement.LabelName;
                    _context.AnnouncementsHistory.Update(announcementHistory);
                }

                await _context.SaveChangesAsync();

                return Ok(new { message = "ok" });
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating announcement.");
            }
        }






        [HttpDelete("deleteannouncement/{announcementId}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAnnouncement(int announcementId)
        {
            try
            {
                var existingAnnouncement = await _context.Announcements.FindAsync(announcementId);

                if (existingAnnouncement == null)
                {
                    return NotFound("Announcement not found.");
                }

                _context.Announcements.Remove(existingAnnouncement);
                await _context.SaveChangesAsync();

                switch (existingAnnouncement.PublishedTo)
                {
                    case 1:
                        var adminAnnouncement = await _context.AdminAnnouncements.FirstOrDefaultAsync(a => a.AnnouncementId == announcementId);
                        if (adminAnnouncement != null)
                        {
                            _context.AdminAnnouncements.Remove(adminAnnouncement);
                        }
                        break;

                    case 2:
                        var hrAnnouncement = await _context.HrAnnouncements.FirstOrDefaultAsync(a => a.AnnouncementId == announcementId);
                        if (hrAnnouncement != null)
                        {
                            _context.HrAnnouncements.Remove(hrAnnouncement);
                        }
                        break;

                    case 3:
                        var employeeAnnouncement = await _context.EmployeeAnnouncements.FirstOrDefaultAsync(a => a.AnnouncementId == announcementId);
                        if (employeeAnnouncement != null)
                        {
                            _context.EmployeeAnnouncements.Remove(employeeAnnouncement);
                        }
                        break;

                    default:
                        return BadRequest("Invalid PublishedTo value.");
                }

                var announcementHistory = await _context.AnnouncementsHistory.FirstOrDefaultAsync(a => a.AnnouncementId == announcementId);
                if (announcementHistory != null)
                {
                    _context.AnnouncementsHistory.Remove(announcementHistory);
                }


                await _context.SaveChangesAsync();

                return Ok(new { message = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting announcement.");
            }
        }


        [HttpGet("getannouncementbyid/{announcementId}")]
        public async Task<IActionResult> GetAnnouncementById(int announcementId)
        {
            try
            {
                var announcement = await _context.Announcements.FindAsync(announcementId);

                if (announcement == null)
                {
                    return NotFound("Announcement not found.");
                }

                return Ok(announcement);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving announcement by ID.");
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////







        [HttpPost("addntastory")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddNTAstory([FromBody] NTAstory ntaStory)
        {
            try
            {
                var newNTAstory = new NTAstory
                {
                    Header = ntaStory.Header,
                    Body = ntaStory.Body,
                    PublishedTo = ntaStory.PublishedTo,
                    AnnouncementDate = ntaStory.AnnouncementDate,
                    Createdby = User.Identity.Name
                };


                _context.NTAstories.Add(newNTAstory);
                await _context.SaveChangesAsync();

                switch (ntaStory.PublishedTo)
                {
                    case 1:
                        var adminNTAstory = new AdminNTAstory
                        {
                            Header = ntaStory.Header,
                            Body = ntaStory.Body,
                            PublishedTo = ntaStory.PublishedTo,
                            AnnouncementDate = ntaStory.AnnouncementDate,
                            StorytId = newNTAstory.Id,
                            Createdby = User.Identity.Name

                        };
                        _context.AdminNTAstories.Add(adminNTAstory);
                        await _context.SaveChangesAsync();
                        break;

                    case 2:
                        var hrNTAstory = new HrNTAstory
                        {
                            Header = ntaStory.Header,
                            Body = ntaStory.Body,
                            PublishedTo = ntaStory.PublishedTo,
                            AnnouncementDate = ntaStory.AnnouncementDate,
                            StorytId = newNTAstory.Id,
                            Createdby = User.Identity.Name

                        };
                        _context.HrNTAstories.Add(hrNTAstory);
                        await _context.SaveChangesAsync();
                        break;

                    case 3:
                        var userNTAstory = new UserNTAstory
                        {
                            Header = ntaStory.Header,
                            Body = ntaStory.Body,
                            PublishedTo = ntaStory.PublishedTo,
                            AnnouncementDate = ntaStory.AnnouncementDate,
                            StorytId = newNTAstory.Id,
                            Createdby = User.Identity.Name


                        };
                        _context.UserNTAstories.Add(userNTAstory);
                        await _context.SaveChangesAsync();
                        break;

                    default:
                        return BadRequest("Invalid PublishedTo value.");
                }

               

                var newNTAstoryId = newNTAstory.Id;

                var ntaStoryHistory = new NTAstoryHistory
                {
                    StoryId = newNTAstoryId,
                    Header = ntaStory.Header,
                    CreatedBy = User.Identity.Name,
                    CreationDate = DateTime.UtcNow,
                    LastUpdatedDate = DateTime.UtcNow,
                    LastUpdatedBy = User.Identity.Name
                };

                _context.NTAstoriesHistory.Add(ntaStoryHistory);
                await _context.SaveChangesAsync();

                return Ok(new { message = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding NTAstory.");
            }
        }










[HttpPut("updatentastory/{ntaStoryId}")]
[Authorize(Roles = "Admin")]
public async Task<IActionResult> UpdateNTAstory(int ntaStoryId, [FromBody] NTAstory updatedNTAstory)
{
    try
    {
        var existingNTAstory = await _context.NTAstories.FindAsync(ntaStoryId);

        if (existingNTAstory == null)
        {
            return NotFound("NTAstory not found.");
        }

                int originalPublishedTo = existingNTAstory.PublishedTo;


                existingNTAstory.Header = updatedNTAstory.Header;
        existingNTAstory.Body = updatedNTAstory.Body;
        existingNTAstory.AnnouncementDate = updatedNTAstory.AnnouncementDate;

        _context.NTAstories.Update(existingNTAstory);
        await _context.SaveChangesAsync();
                existingNTAstory.PublishedTo = originalPublishedTo;

        switch (existingNTAstory.PublishedTo)
        {
            case 1:
                var adminNTAstory = await _context.AdminNTAstories.FirstOrDefaultAsync(a => a.StorytId == ntaStoryId);
                if (adminNTAstory != null)
                {
                    adminNTAstory.Header = updatedNTAstory.Header;
                    adminNTAstory.Body = updatedNTAstory.Body;
                    adminNTAstory.AnnouncementDate = updatedNTAstory.AnnouncementDate;
                    _context.AdminNTAstories.Update(adminNTAstory);
                            await _context.SaveChangesAsync();

                        }
                        break;

            case 2:
                var hrNTAstory = await _context.HrNTAstories.FirstOrDefaultAsync(a => a.StorytId == ntaStoryId);
                if (hrNTAstory != null)
                {
                    hrNTAstory.Header = updatedNTAstory.Header;
                    hrNTAstory.Body = updatedNTAstory.Body;
                    hrNTAstory.AnnouncementDate = updatedNTAstory.AnnouncementDate;
                    _context.HrNTAstories.Update(hrNTAstory);
                            await _context.SaveChangesAsync();

                        }
                        break;

            case 3:
                var userNTAstory = await _context.UserNTAstories.FirstOrDefaultAsync(a => a.StorytId == ntaStoryId);
                if (userNTAstory != null)
                {
                    userNTAstory.Header = updatedNTAstory.Header;
                    userNTAstory.Body = updatedNTAstory.Body;
                    userNTAstory.AnnouncementDate = updatedNTAstory.AnnouncementDate;
                    _context.UserNTAstories.Update(userNTAstory);

                            await _context.SaveChangesAsync();

                        }
                        break;

            default:
                return BadRequest("Invalid PublishedTo value.");
        }

        var ntaStoryHistory = await _context.NTAstoriesHistory
            .FirstOrDefaultAsync(a => a.StoryId == ntaStoryId);

        if (ntaStoryHistory != null)
        {
            ntaStoryHistory.Header = updatedNTAstory.Header;
            ntaStoryHistory.LastUpdatedBy = User.Identity.Name;
            ntaStoryHistory.LastUpdatedDate = DateTime.UtcNow;

            _context.NTAstoriesHistory.Update(ntaStoryHistory);
        }

        await _context.SaveChangesAsync();

                return Ok(new { message = "ok" });
            }
    catch (Exception ex)
    {
        return StatusCode(StatusCodes.Status500InternalServerError, "Error updating NTAstory.");
    }
}







        [HttpGet("getntastories")]
        public IActionResult GetNTAstories()
        {
            var ntaStories = _context.NTAstories.ToList();
            return Ok(ntaStories);
        }

        [HttpGet("getadminntastories")]
        public IActionResult GetAdminNTAstories()
        {
            var adminNTAstories = _context.AdminNTAstories.ToList();
            return Ok(adminNTAstories);
        }

        [HttpGet("gethrntastories")]
        public IActionResult GetHrNTAstories()
        {
            var hrNTAstories = _context.HrNTAstories.ToList();
            return Ok(hrNTAstories);
        }

        [HttpGet("getuserntastories")]
        public IActionResult GetUserNTAstories()
        {
            var userNTAstories = _context.UserNTAstories.ToList();
            return Ok(userNTAstories);
        }

        [HttpGet("getntastorieshistory")]
        public IActionResult GetNTAstoriesHistory()
        {
            var ntaStoriesHistory = _context.NTAstoriesHistory.ToList();
            return Ok(ntaStoriesHistory);
        }





        [HttpDelete("deletentastory/{ntaStoryId}")]
        
        public async Task<IActionResult> DeleteNTAStory(int ntaStoryId)
        {
            try
            {
                var existingNTAstory = await _context.NTAstories.FindAsync(ntaStoryId);

                if (existingNTAstory == null)
                {
                    return NotFound("NTAstory not found.");
                }

                _context.NTAstories.Remove(existingNTAstory);

                switch (existingNTAstory.PublishedTo)
                {
                    case 1:
                        var adminNTAstory = await _context.AdminNTAstories.FirstOrDefaultAsync(a => a.StorytId == ntaStoryId);
                        if (adminNTAstory != null)
                        {
                            _context.AdminNTAstories.Remove(adminNTAstory);
                        }
                        break;

                    case 2:
                        var hrNTAstory = await _context.HrNTAstories.FirstOrDefaultAsync(a => a.StorytId == ntaStoryId);
                        if (hrNTAstory != null)
                        {
                            _context.HrNTAstories.Remove(hrNTAstory);
                        }
                        break;

                    case 3:
                        var userNTAstory = await _context.UserNTAstories.FirstOrDefaultAsync(a => a.StorytId == ntaStoryId);
                        if (userNTAstory != null)
                        {
                            _context.UserNTAstories.Remove(userNTAstory);
                        }
                        break;

                    default:
                        return BadRequest("Invalid PublishedTo value.");
                }

                var ntaStoryHistory = await _context.NTAstoriesHistory.FirstOrDefaultAsync(a => a.StoryId == ntaStoryId);
                if (ntaStoryHistory != null)
                {
                    _context.NTAstoriesHistory.Remove(ntaStoryHistory);
                }

                await _context.SaveChangesAsync();

                return Ok(new { message = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting NTAstory.");
            }
        }


        [HttpGet("getntastorybyid/{ntaStoryId}")]
        public async Task<IActionResult> GetNTAStoryById(int ntaStoryId)
        {
            try
            {
                var ntaStory = await _context.NTAstories.FirstOrDefaultAsync(s => s.Id == ntaStoryId);

                if (ntaStory == null)
                {
                    return NotFound("NTAstory not found.");
                }

                return Ok(ntaStory);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error fetching NTAstory.");
            }
        }




        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////



















        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////






        [Authorize(Roles = "Admin, HR, User")]
        [HttpPost("addmeeting")]
        public async Task<IActionResult> AddMeeting([FromBody] Meeting meeting)
        {
            try
            {
                meeting.CreatedBy = User.Identity.Name;
                _context.Meetings.Add(meeting);
                await _context.SaveChangesAsync();

                var attendees = new List<Attendee>();

                foreach (var username in meeting.AttendeeUsernames)
                {
                    attendees.Add(new Attendee
                    {
                        Username = username,
                        MeetingId = meeting.Id,
                        Meeting = meeting,
                        MeetingDate = meeting.MeetingDate,
                        meeting_CreatedBy = User.Identity.Name

                });
                }

                await _context.Attendees.AddRangeAsync(attendees);
                await _context.SaveChangesAsync();

                return Ok(new { message = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding meeting.");
            }
        }


        [HttpGet("getallmeetings")]
        public IActionResult GetAllMeetings()
        {
            var meetings = _context.Meetings.ToList();

            foreach (var meeting in meetings)
            {
                meeting.AttendeeUsernames = _context.Attendees
                    .Where(a => a.MeetingId == meeting.Id)
                    .Select(a => a.Username)
                    .ToList();
            }
            return Ok(meetings);
        }





        [HttpGet("getallattendees")]
        public IActionResult GetAllAttendees()
        {
            var attendees = _context.Attendees.ToList();
            return Ok(attendees);
        }



        [HttpGet("attendeeDatesByUsername/{username}")]
        public IActionResult GetAttendeeDatesByUsername(string username)
        {
            var attendeeMeetingInfo = _context.Attendees
                .Where(a => a.Username == username)
                .Select(a => new
                {
                    MeetingDate = a.MeetingDate,
                    Meeting = a.Meeting 
                })
                .ToList();

            return Ok(attendeeMeetingInfo);
        }




        [Authorize(Roles = "Admin, HR, User")]
        [HttpPut("updatemeeting/{meetingId}")]
        public async Task<IActionResult> UpdateMeeting(int meetingId, [FromBody] Meeting updatedMeeting)
        {
            try
            {
                var existingMeeting = await _context.Meetings.FindAsync(meetingId);

                if (existingMeeting == null)
                {
                    return NotFound("Meeting not found");
                }

                existingMeeting.MeetingName = updatedMeeting.MeetingName;
                existingMeeting.MeetingType = updatedMeeting.MeetingType;
                existingMeeting.Description = updatedMeeting.Description;
                existingMeeting.MeetingLocation = updatedMeeting.MeetingLocation;
                existingMeeting.MeetingLink = updatedMeeting.MeetingLink;
                existingMeeting.AnnouncementDate = updatedMeeting.AnnouncementDate;
                existingMeeting.MeetingDate = updatedMeeting.MeetingDate;
                var existingAttendees = _context.Attendees.Where(a => a.MeetingId == meetingId);
                _context.Attendees.RemoveRange(existingAttendees);

                foreach (var username in updatedMeeting.AttendeeUsernames)
                {
                    var newAttendee = new Attendee
                    {
                        Username = username,
                        MeetingId = meetingId,
                        Meeting = existingMeeting,
                        MeetingDate = existingMeeting.MeetingDate,
                        meeting_CreatedBy = existingMeeting.CreatedBy
                    };

                    _context.Attendees.Add(newAttendee);
                }

                await _context.SaveChangesAsync();

                return Ok(new { message = "Meeting updated successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating meeting.");
            }
        }



        [HttpGet("meetingbyId/{id}")]
        public async Task<ActionResult<Meeting>> GetMeetingById(int id)
        {
            var meeting = await _context.Meetings.FindAsync(id);

            if (meeting == null)
            {
                return NotFound();
            }

            return meeting;
        }


    }

}
