using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly Data.DataContext _context;

        public ProjectController(Data.DataContext context)
        {
            _context = context;
        }

        // GET api/project
        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _context.Projects.ToListAsync();
            return Ok(projects);
        }

        // GET api/project/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound(new { Message = "Project not found" });
            }
            return Ok(project);
        }

        // POST api/project
        [HttpPost]
        
        public async Task<IActionResult> CreateProject(Project project) 
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProjectById), new { id = project.Id }, project);
        }


        // PUT api/project/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, Project project)
        {
            
            var existingProject = await _context.Projects.FindAsync(id);
            if (existingProject == null)
            {
                return NotFound(new { Message = "Project not found" });
            }

            
            existingProject.FirstName = project.FirstName;
            existingProject.LastName = project.LastName;
            existingProject.Department = project.Department;

            
            await _context.SaveChangesAsync();

            
            return Ok(existingProject);
        }



        // DELETE api/project/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound(new { Message = "Project not found" });
            }

            
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            
            return NoContent();
        }


    }
}



