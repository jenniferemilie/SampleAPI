using Exo_Linq_Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApi.Entities;
using SampleApi.Models;
using SampleApi.Repositories;

namespace SampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private IContext _ctx;
        private IRepository<ProfessorPOCO, int> repo;
        private IRepository<SectionPOCO, int> sectionRepo;
        private IRepository<CoursePOCO, int> courseRepo;
        public ProfessorController(IContext context, 
                                   IRepository<ProfessorPOCO,int> repost,
                                   IRepository<SectionPOCO, int> SectionRepo,
                                   IRepository<CoursePOCO, int> CourseRepo)
        {
            _ctx = context; 
            repo = repost;
            sectionRepo = SectionRepo;
            courseRepo = CourseRepo;
        }
        [HttpGet]
        public IActionResult GetALLProfessor()
        {
            return Ok(_ctx.Professors);
        }

        [HttpGet]
        [Route("{idPofessor}")]

        public IActionResult GetProfessorById(int professorId)
        {
            ProfessorPOCO st = repo.Get(professorId);
            if (st.Professor_ID != 0)
            {
                ProfessorDTOV2 dto = new ProfessorDTOV2()
                {
                    Professor_ID = st.Professor_ID,
                    Professor_Surname = st.Professor_Surname,
                    Professor_Email = st.Professor_Email,
                    Professor_Office = st.Professor_Office,
                    Section_Name = sectionRepo.Get(st.Section_ID).Section_Name,
                    
                };
                return Ok(dto);
            }
            return BadRequest();
        }

    }
}
