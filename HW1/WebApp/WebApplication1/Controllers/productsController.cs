using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class productsController : ApiController
    {
        // GET: products
        public IHttpActionResult Get()
        {
            try
            {
                Product[] productsArr = productDbServ.GetAllProducts();
                return Ok(productsArr);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}