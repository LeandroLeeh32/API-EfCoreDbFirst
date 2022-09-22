# EfCoreDbFirst
Usando o Scaffold-DbContext dentro da pasta do projeto.

Banco PostgreSql

Scaffold-DbContext "Server=localhost; Database=leandro; user id=postgres; password=123;" Npgsql.EntityFrameworkCore.PostgreSQL 
                    -Context "leandroDbContext" -OutputDir Infrastructure\DataModels
                   
# Program.cs
Inclusão da linha de comando
builder.Services.AddDbContext<leandroDbContext>();

# Controller

[HttpGet]
public async Task<IActionResult> GetProtudo()
{
    return Ok(await _context.TbPessoas.ToListAsync());
}
