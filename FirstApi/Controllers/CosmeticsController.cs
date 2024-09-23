
using FirstApi.Data;
using FirstApi.Models;
using FirstApi.Models.DTOs;


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace firstapi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class costmeticsController : ControllerBase
	{
		private readonly CosmeticsContext db;
		public costmeticsController(CosmeticsContext _db)
		{
			db = _db;
		}
		[HttpGet]
		public IActionResult GetCosmetics()
		{
			return Ok(db.Makeup.ToList());
		}
		[HttpPost]
		public IActionResult AddCosmetics(MakeDTO AddMake)
		{
			if(AddMake != null)
			{
				var company = new Makeup()
				{
					Name = AddMake.Name,
					Price = AddMake.Price,
				};
				var NewsAdd=db.Makeup.Add(company);
				db.SaveChanges();
				return Ok(NewsAdd.Entity);

			}
			else
			{
				return BadRequest();
			}
		}
		[HttpPut]
		public IActionResult UpdateCosmetics(MakeDTO EditMake,int id)
		{
			if (EditMake != null && id!=null)
			{
				var company = db.Makeup.Find(id);

				company.Name = EditMake.Name;
				company.Price = EditMake.Price;
			
				var NewsAdd = db.Makeup.Update(company);
				db.SaveChanges();
				return Ok(NewsAdd.Entity);

			}
			else
			{
				return BadRequest();
			}
		}
		[HttpDelete]
		public IActionResult DeleteCosmetics(int id, MakeDTO Delete)
		{
			if (id != null && Delete != null)
			{
				var company = db.Makeup.Find(id);

				company.Name = Delete.Name;
				company.Price = Delete.Price;

				var NewsDelete = db.Makeup.Remove(company);
				db.SaveChanges();
				return Ok(NewsDelete.Entity);
			}
			else
			{
				var dlete = "Not Deleted";
				return BadRequest();
			}
		}
		[HttpGet ("{PageNo}/{PageSize}")]

		public IActionResult GetCosmetics(int pageno , int pagesize)
		{
			int pagenum = pageno;
			int pagesiz = pagesize;

			if(pagenum == 1) { pageno = 1; }
			if(pagesiz == 1) { pagesize = 1; }

			var medicie = db.Makeup.Skip((pageno - 1)* pagesize).Take(pagesize).ToList();
			return Ok(medicie);

     }
    }

}
