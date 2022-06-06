using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceBeers.Controllers.Response;
using WebServiceBeers.Controllers.Request;
using WebServiceBeers.Models;

namespace WebServiceBeers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            ServiceResponse<List<Beer>> oRes = new ServiceResponse<List<Beer>>();

            try
            {
                using (DBBlazorContext db = new DBBlazorContext())
                {
                    var beers = db.Beers.ToList();
                    oRes.Success = true;
                    oRes.Data = beers;
                }
            }
            catch (Exception ex)
            {
                oRes.Message = ex.Message;
            }

            return Ok(oRes);
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            ServiceResponse<Beer> oRes = new ServiceResponse<Beer>();

            try
            {
                using (DBBlazorContext db = new DBBlazorContext())
                {
                    var beers = db.Beers.Find(Id);
                    oRes.Success = true;
                    oRes.Data = beers;
                }
            }
            catch (Exception ex)
            {
                oRes.Message = ex.Message;
            }

            return Ok(oRes);
        }

        [HttpPost]
        public IActionResult Add(ServiceRequest model)
        {
            ServiceResponse<Object> oRes = new ServiceResponse<Object>();

            try
            {
                using (DBBlazorContext db = new DBBlazorContext())
                {
                    Beer oBeer = new Beer();
                    oBeer.Name = model.Name;
                    oBeer.Brand = model.Brand;
                    db.Beers.Add(oBeer);
                    db.SaveChanges();
                    oRes.Success = true;
                    oRes.Data = oBeer;
                }
            }
            catch (Exception ex)
            {
                oRes.Message = ex.Message;
            }

            return Ok(oRes);
        }

        [HttpPut]
        public IActionResult Edit(ServiceRequest model)
        {
            ServiceResponse<Object> oRes = new ServiceResponse<Object>();

            try
            {
                using (DBBlazorContext db = new DBBlazorContext())
                {
                    Beer oBeer = db.Beers.Find(model.Id);
                    oBeer.Name = model.Name;
                    oBeer.Brand = model.Brand;
                    db.Entry(oBeer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRes.Success = true;
                    oRes.Data = oBeer;
                }
            }
            catch (Exception ex)
            {
                oRes.Message = ex.Message;
            }

            return Ok(oRes);
        }

        [HttpDelete("{Id}")]
        public IActionResult Remove(int Id)
        {
            ServiceResponse<Object> oRes = new ServiceResponse<Object>();

            try
            {
                using (DBBlazorContext db = new DBBlazorContext())
                {
                    Beer oBeer = db.Beers.Find(Id);
                    db.Remove(oBeer);
                    db.SaveChanges();
                    oRes.Success = true;
                    oRes.Data = oBeer;
                }
            }
            catch (Exception ex)
            {
                oRes.Message = ex.Message;
            }

            return Ok(oRes);
        }
    }
}
