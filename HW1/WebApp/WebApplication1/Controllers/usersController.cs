using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class usersController : ApiController
    {
        public IHttpActionResult Get()
        {
			try
			{
				User[] usersArr = UsersDBServ.GetAllUsers();
				return Ok(usersArr);
			}
			catch (Exception ex )
			{

				return  BadRequest(ex.Message);
			}
        }
    }
}
