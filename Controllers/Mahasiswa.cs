using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace modul9_1302223045.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mahasiswa : ControllerBase
    {
        private static List<MhsModel> Mhs = new List<MhsModel>
        {
            new MhsModel { nama = "Harits Azfa", nim = "1302223045", year = 2022, Course = new List<string>() { "Kpl", "Pbo", "Basdat" } },
            new MhsModel { nama = "M Aldino", nim = "1302223041", year = 2022, Course = new List<string>() { "Kpl", "Pbo", "Basdat" } },
            new MhsModel { nama = "M Ghifari", nim = "1302223041", year = 2022, Course = new List<string>() { "Kpl", "Pbo", "Basdat" } },
            new MhsModel { nama = "Fajar Jelang", nim = "1302223041", year = 2022, Course = new List<string>() { "Kpl", "Pbo", "Basdat" } }
        };

        [HttpGet]
        public IEnumerable<MhsModel> Get() 
        {
            return Mhs;
        }

        [HttpGet("{id}")]
        public ActionResult<MhsModel> Get(int id)
        {
            if (id < 0 || id >= Mhs.Count)
            {
                return NotFound();
            }

            return Mhs[id];
        }

        [HttpPost]
        public IActionResult Post([FromBody] MhsModel mahasiswa) 
        { 
            Mhs.Add(mahasiswa);
            return CreatedAtAction(nameof(Get), new {id = Mhs.IndexOf(mahasiswa)}, mahasiswa);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= Mhs.Count)
            {
                return NotFound();
            }

            Mhs.RemoveAt(id);
            return NoContent();
        }
    }

    public class MhsModel
    {
        public string nama {  get; set; }
        public string nim {  get; set; }
        public int year {  get; set; }
        public List<string> Course { get; set; }
    }

}