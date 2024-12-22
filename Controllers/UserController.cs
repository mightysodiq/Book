using Book.Api.Dtos;
using Book.Core.Domains;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System.Net;

namespace Book.Api.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private string Connection { get; set; }

        public UserController(IConfiguration config)
        {
            Connection = config.GetValue<string>("ConnectionString");
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(CreateUserDto user)
        {
            string sql = "INSERT INTO USERS VALUES (@username,@password,@Email,null)";
            using (var db = new SqlConnection(Connection))
            { 
                db.Execute(sql, user);
            }
            return StatusCode(Convert.ToInt32(HttpStatusCode.OK), new { User = user });
        }
        [HttpGet]
        [Route("Get")]
        public List<User> GetAllUsers()
        {
            string sql = "SELECT * FROM USERS";
            using (var db = new SqlConnection(Connection))
            {
                var users = db.Query<User>(sql);
                return users.ToList();
            }  
        } 
                
        
        [HttpPut]
        [Route("Update")]
        public IActionResult Update(UpdateUserDto user)
        {
            string sql = "UPDATE USERS SET password=@password,email=@Email where id =@Id)";
            using (var db = new SqlConnection(Connection)) 
            {
                    db.Execute(sql, user);
            }
               return StatusCode(Convert.ToInt32(HttpStatusCode.OK), new { Message = "Success" });
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete (int userId)
        {
                string sql = "DELETE USERS where id=@userId)";
                using (var db = new SqlConnection(Connection))
                {
                    db.Execute(sql, new { userId }); 
                }
                return StatusCode(Convert.ToInt32(HttpStatusCode.OK), new { Message = "Success" });
        }
        

    }   
}
