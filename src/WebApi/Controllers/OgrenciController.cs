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
    public class OgrenciController : ControllerBase
    {
        private readonly IRepository<Domain.Entities.Ogrenci> ogrenciRepository;
        private readonly IRepository<Domain.Entities.Okul> okulRepository;
        private readonly IRepository<Domain.Entities.Ogretmen> ogretmenRepository;
        private readonly IMapper _mapper;
        public OgrenciController(IRepository<Domain.Entities.Ogrenci> ogrenciRepository, 
            IRepository<Domain.Entities.Okul> okulRepository,
            IRepository<Domain.Entities.Ogretmen> ogretmenRepository, 
            IMapper mapper)
        {
            this.ogrenciRepository = ogrenciRepository;
            this.okulRepository = okulRepository;
            this.ogretmenRepository = ogretmenRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_mapper.Map<List<Ogrenci>>(ogrenciRepository.All().ToList()));
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var data = ogrenciRepository.Where((ogrenci) => ogrenci._id == id).FirstOrDefault();
            return Ok(_mapper.Map<Ogrenci>(data));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Ogrenci ogrenci)
        {
            if (!ModelState.IsValid || ogrenci == null) return BadRequest();

            var mappedOgrenci = _mapper.Map<Domain.Entities.Ogrenci>(ogrenci);

            if (ogrenciRepository.Add(mappedOgrenci))
            {
                foreach (string item in ogrenci.Okullar)
                {
                    Domain.Entities.Okul normal = okulRepository.Where(o => o._id == int.Parse(item)).FirstOrDefault();
 
                    if (normal.Ogrenciler == null)
                    {
                        normal.Ogrenciler = new List<string>() { mappedOgrenci._id.ToString() };
                    }
                    else
                    {
                        normal.Ogrenciler.Add(mappedOgrenci._id.ToString());
                    }

                    okulRepository.Update(normal);
                }

                foreach (string item in ogrenci.Ogretmenler)
                {
                    Domain.Entities.Ogretmen normal = ogretmenRepository.Where(o => o._id == int.Parse(item)).FirstOrDefault();

                    if (normal.Ogrenciler == null)
                    {
                        normal.Ogrenciler = new List<string>() { mappedOgrenci._id.ToString() };
                    }
                    else
                    {
                        normal.Ogrenciler.Add(mappedOgrenci._id.ToString());
                    }

                    ogretmenRepository.Update(normal);
                }

                return Ok(ogrenci);
            }

            return BadRequest();
        }
    }
}