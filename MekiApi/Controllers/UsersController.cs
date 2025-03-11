using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MekiApi.Data;
using MekiApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MekiApi.Controllers
{
    [Route("api/users")] // Route de base : /api/users
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Injection du contexte de base de données
        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            // Retourne tous les utilisateurs avec leurs scores
            return await _context.Users.Include(u => u.Scores).ToListAsync();
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            // Recherche l'utilisateur par son ID
            var user = await _context.Users.Include(u => u.Scores).FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound(); // Retourne une erreur 404 si l'utilisateur n'existe pas
            }

            return user;
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            // Ajoute l'utilisateur à la base de données
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Retourne l'utilisateur créé avec un code 201 (Created)
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest(); // Retourne une erreur 400 si l'ID ne correspond pas
            }

            // Marque l'utilisateur comme modifié
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Users.Any(u => u.Id == id))
                {
                    return NotFound(); // Retourne une erreur 404 si l'utilisateur n'existe pas
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); // Retourne un code 204 (No Content)
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            // Recherche l'utilisateur par son ID
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound(); // Retourne une erreur 404 si l'utilisateur n'existe pas
            }

            // Supprime l'utilisateur de la base de données
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent(); // Retourne un code 204 (No Content)
        }
    }
}