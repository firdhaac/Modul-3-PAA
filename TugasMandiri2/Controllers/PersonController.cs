using TugasMandiri2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TugasMandiri2.Controllers
{
    public class PersonController : Controller
    {
        private string __constr;

        public PersonController(IConfiguration configuration)
        {
            __constr = configuration.GetConnectionString("WebApiDatabase");
        }

        public IActionResult index()
        {
            return View();
        }

        // READ //

        [HttpGet("api/murid")]

        public ActionResult<Murid> ListPerson()
        {
            PersonContext context = new PersonContext(this.__constr);
            List<Murid> ListPerson = context.ListMurid();
            return Ok(ListPerson);
        }

        // CREATE //

        [HttpPost("api/murid/create")]
        public IActionResult CreatePerson([FromBody] Murid murid)
        {
            PersonContext context = new PersonContext(this.__constr);
            context.AddMurid(murid);
            return Ok("Data murid berhasil dibuat.");
        }

        // UPDATE //

        [HttpPut("api/murid/update/{id}")]
        public IActionResult UpdatePerson(int id, [FromBody] Murid murid)
        {
            murid.id_murid = id;
            PersonContext context = new PersonContext(this.__constr);
            context.UpdateMurid(murid);
            return Ok("Data murid berhasil diperbarui");
        }

        // DELETE //

        [HttpDelete("api/murid/delete/{id}")]
        public IActionResult DeletePerson(int id)
        {
            PersonContext context = new PersonContext(this.__constr);
            context.DeleteMurid(id);
            return Ok("Data murid berhasil dihapus");
        }

    }

}