using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OkulController : ControllerBase
    {
        private readonly IRepository<Domain.Entities.Okul> okulRepository;
        private readonly IRepository<Domain.Entities.Ogrenci> ogrenciRepository;
        private readonly IMapper _mapper;
        public OkulController(IRepository<Domain.Entities.Okul> okulRepository, IRepository<Domain.Entities.Ogrenci> ogrenciRepository, IMapper mapper)
        {
            this.okulRepository = okulRepository;
            this.ogrenciRepository = ogrenciRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(okulRepository.All());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(okulRepository.Where((okul) =>  okul._id == id ));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Okul okul)
        {
            if (!ModelState.IsValid || okul == null) return BadRequest();

            if (okulRepository.Add(_mapper.Map<Domain.Entities.Okul>(okul)))
                return Ok(okul);

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Okul value)
        {
            var currentData = okulRepository.Where((okul) => okul._id == id).FirstOrDefault();

            currentData.Adres = value.Adres;
            currentData.Ilce = value.Ilce;
            currentData.Sehir = value.Sehir;

            return Ok(okulRepository.Update(currentData));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(okulRepository.Delete(okulRepository.Where((okul) => okul._id == id).FirstOrDefault()));
        }

        [HttpGet("{id}/ogrenciler")]
        public ActionResult<string> Ogrenciler(int id)
        {
            var ogrenciIDs = okulRepository.Where((okul) => okul._id == id).FirstOrDefault().Ogrenciler;
            List<Ogrenci> data = new List<Ogrenci>();

            foreach (string item in ogrenciIDs)
            {
                data.Add(_mapper.Map<Ogrenci>(ogrenciRepository.Where(o => o._id == int.Parse(item)).FirstOrDefault()));
            }

            return Ok(data);
        }
    }
}
