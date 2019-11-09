using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OgretmenController : ControllerBase
    {
        private readonly IRepository<Domain.Entities.Ogretmen> ogretmenRepository;
        private readonly IRepository<Domain.Entities.Ogrenci> ogrenciRepository;
        private readonly IMapper _mapper;
        public OgretmenController(IRepository<Domain.Entities.Ogretmen> ogretmenRepository, IRepository<Domain.Entities.Ogrenci> ogrenciRepository, IMapper mapper)
        {
            this.ogretmenRepository = ogretmenRepository;
            this.ogrenciRepository = ogrenciRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_mapper.Map<List<Ogretmen>>(ogretmenRepository.All().ToList()));
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var data = ogretmenRepository.Where((ogretmen) => ogretmen._id == id).FirstOrDefault();
            return Ok(_mapper.Map<Ogretmen>(data));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Ogretmen ogretmen)
        {
            if (!ModelState.IsValid || ogretmen == null) return BadRequest();

            if (ogretmenRepository.Add(_mapper.Map<Domain.Entities.Ogretmen>(ogretmen)))
                return Ok(ogretmen);

            return BadRequest();
        }

        [HttpGet("{id}/ogrenciler")]
        public ActionResult<string> Ogrenciler(int id)
        {
            var ogrenciIDs = ogretmenRepository.Where((o) => o._id == id).FirstOrDefault().Ogrenciler ?? new List<string>();
            List<Ogrenci> data = new List<Ogrenci>();

            foreach (string item in ogrenciIDs)
            {
                data.Add(_mapper.Map<Ogrenci>(ogrenciRepository.Where(o => o._id == int.Parse(item)).FirstOrDefault()));
            }

            return Ok(data);
        }
    }
}