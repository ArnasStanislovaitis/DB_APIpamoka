using DB_ir_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace DB_ir_API
{
    [ApiController]
    [Route("/")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly PavyzdinisDbContext _dbContext;



        public WeatherForecastController(PavyzdinisDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        [HttpGet]
        [Route("/daiktai")]
        public List<Daiktas> VisiDaiktai()
        {
            return _dbContext.Daiktai.Where(x => x.Pavadinimas != "kazkas").ToList();
        }
        [HttpGet]
        [Route("/automobiliai")]
        public List<Automobilis> VisiAutomobiliai()
        {
            return _dbContext.Automobiliai.Where(x => x.Marke != "kazkas").ToList();
        }



        [HttpGet]
        [Route("/savininkai")]
        public List<Savininkas> VisiSavininkai()
        {
            return _dbContext.Savininkai.Where(x => x.Vardas != "kazkas").ToList();
        }



        [HttpGet]
        [Route("/pridetiDaikta/{savininkoId}")]
        public void PridetiDaikta(int? savininkoId)
        {
            var savininkas = _dbContext.Savininkai.Where(x => x.Id == savininkoId).FirstOrDefault();
            _dbContext.Daiktai.Add(new Daiktas() { Pavadinimas = "Telefonas", SavininkasId = savininkas != null ? savininkas.Id : 1 });
            _dbContext.SaveChanges();
        }



        [HttpGet]
        [Route("/pridetiSavininka")]
        public void PridetiSavininka()
        {
            _dbContext.Savininkai.Add(new Savininkas() { Vardas = "Jonas" });
            _dbContext.SaveChanges();
        }
        [HttpDelete]
        [Route("/daiktas/{daiktoID:int?}")]
        public void IstrintiDaikta(int? daiktoId)
        {
            var daiktas= _dbContext.Daiktai.Where(x=>x.ID == daiktoId).FirstOrDefault();  
            if (daiktas != null)
            {
                _dbContext.Daiktai.Remove(daiktas);
                _dbContext.SaveChanges();
            }    
        }
        [HttpDelete]
        [Route("/savininkas")]
        public void IstrintiSavininka(int? savininkoID)
        {
            var savininkas = _dbContext.Savininkai.Where(x => x.Id == savininkoID).FirstOrDefault();
            if (savininkoID != null)
            {
               _dbContext.Savininkai.Remove(savininkas);
                _dbContext.SaveChanges();
            }    
        }
        [HttpGet]
        [Route("/daiktaiPagalId")]
        public ActionResult<Daiktas?> VisiDaiktai(int? daiktoID)
        {
            var daiktas = _dbContext.Daiktai.Where(x => x.ID == daiktoID).FirstOrDefault();
            if(daiktoID != null)
            {
                return daiktas;
            }
            return NotFound();
        }
        [HttpGet]
        [Route ("/savininkasPagalID")]
        public ActionResult<Savininkas?> SavininkasPagalID(int? savininkoID)
        {
            var savininkas = _dbContext.Savininkai.Where(x => x.Id == savininkoID).FirstOrDefault();
            if(savininkoID != null)
            {
                return savininkas;
            }
            return NotFound();
        }
        //[HttpPost]
        //[Route("/pridetiDaikta")]
        //public void PridetiDaikta([FromBody] DaiktasJSON daiktas)
        //{
        //    var savininkas=_dbContext.Savininkai.Where(x => x.Id == daiktas.SavininkasId).FirstOrDefault();
        //    _dbContext.Daiktai.Add(new Daiktas(){
        //        pavadinimas = daiktas.Pavadinimas
        //        Savininkasid = daiktas.SavininkasId
        //    });
        //    _dbContext.SaveChanges();
        //}

    }
}