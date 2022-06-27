using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CourtTennisBookingV3.Helpers;
using CourtTennisBookingV3.Models;
using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CourtTennisBookingV3.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TennisBooking_v1Context _context;
        private readonly AppSettings _appSettings;
        private static string apiKey = "AIzaSyAzf4g2DuB6hoeS8zMcRgMddBwFDIxnHes";
        private static string apibucket = "tenisu-booking.appspot.com";
        private static string authenEmail = "tuanvuanhse140819@gmail.com";
        private static string authenPassword = "Tuanva123";

        public UserController(TennisBooking_v1Context context, IOptions<AppSettings> AppSettings)
        {
            _context = context;
            _appSettings = AppSettings.Value;
        }

        //=========================================================================test ==>test oke rồi
        //authen
        /// <summary>
        /// Generate Token
        /// </summary>
        [HttpPost("Login")]
        public async Task<ActionResult<IEnumerable<Account>>> Login(LoginVM login)
        {
            var acc = _context.Accounts.SingleOrDefault(acc => acc.Email == login.UserName && acc.Password == login.Password);

            if (acc == null)
            {
                return Ok(new ApiRespone
                {
                    Success = false,
                    Message = "Invalid username/password. Please try again."
                });
            }
            //generate token (cấp token)
            //var claims = new Claim[]
            //{
            //    new Claim(ClaimTypes.Name, acc.Email),
            //    new Claim(ClaimTypes.Role, "User")
            //};
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(claims),
            //    Expires = DateTime.UtcNow.AddDays(1),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};
            //var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new ApiRespone
            {
                Success = true,
                Message = "Authenticate Success!",
                //Data = new
                //{
                //    Token = tokenHandler.WriteToken(token)
                //}
                Data = GenerateToken(acc)
            });
        }


        private TokenModel GenerateToken(Account acc)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, acc.Email),
                    //role
                    new Claim("TokenId", Guid.NewGuid().ToString()),
                    new Claim("RoleId", acc.RoleId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };
            var token = jwtTokenHandler.CreateToken(tokenDescription);
            var accessToken = jwtTokenHandler.WriteToken(token);

            return new TokenModel
            {
                AccessToken = accessToken,
                RefeshToken = GenerateRefreshToken()
            };
        }

        private string GenerateRefreshToken()
        {
            var random = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);

                return Convert.ToBase64String(random);
            }
        }

        //=========================================================================================== firestorage

        /// <summary>
        /// Upload firebase
        /// </summary>
        [HttpPost("UploadFile")]                                                                                                                                //Luân

        public async Task<ActionResult> PostFireBase(IFormFile file)
        {
            try
            {
                var fileUpload = file;
                FileStream fs = null;
                if (fileUpload.Length > 0)
                {
                    {
                        string folderName = "ImagesFile";
                        string path = Path.Combine($"Image", $"Image/{folderName}");
                        if (Directory.Exists(path))
                        {
                            using (fs = new FileStream(Path.Combine(path, fileUpload.FileName), FileMode.Create))
                            {
                                await fileUpload.CopyToAsync(fs);
                            }
                            fs = new FileStream(Path.Combine(path, fileUpload.FileName), FileMode.Open);
                        }
                        else
                        {
                            Directory.CreateDirectory(path);
                        }

                    }

                    var authen = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
                    var a = await authen.SignInWithEmailAndPasswordAsync(authenEmail, authenPassword);
                    var cancel = new CancellationTokenSource();
                    var upload = new FirebaseStorage(
                        apibucket,
                        new FirebaseStorageOptions
                        {
                            AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                            ThrowOnCancel = true
                        }
                        ).Child("Image").Child(fileUpload.FileName).PutAsync(fs, cancel.Token);
                    try
                    {
                        string Link = await upload;
                        return Ok(new { StatusCode = 200, message = "Upload file succesful!" });
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }

                return BadRequest("Upload  fail");

            }
            catch (Exception e)
            {
                return StatusCode(409, new { StatusCode = 409, message = e.Message });
            }
        }




        /// <summary>
        /// Login firebase
        /// </summary>
        [HttpPost("loginfirebase")]                                                                                                                                //Luân

        public async Task<ActionResult> LoginFireBase(string email, string password)
        {
            try
            {
                var a = getAccountByEmail(email);
                if (a != null)
                {
                    var user = _context.Accounts.SingleOrDefault(x => x.Email.ToUpper() == email.ToUpper() && password == x.Password && x.RoleId == "CU" || x.Email.ToUpper() == email.ToUpper() && password == x.Password && x.RoleId == "OC");

                    if (user == null)
                    {
                        return BadRequest("Wrong email or password!");
                    }

                    var authen = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
                    var authetication = await authen.SignInWithEmailAndPasswordAsync(email, password);
                    string token = authetication.FirebaseToken;
                    if (token != "")
                    {
                        return Ok(new { StatusCode = 200, message = "Login successful!"/* data = userid*/ });
                    }

                }

                return BadRequest("invalid");

            }
            catch (Exception e)
            {
                return StatusCode(409, new { StatusCode = 409, message = "Email chưa được đăng kí"});
            }
        }



        private Account getAccountByEmail(string email)
        {
            var account = _context.Accounts.Where(x => x.Email.ToUpper() == email.ToUpper()).FirstOrDefault();
            if (account == null)
                return null;
            return account;
        }

    }
}
