using ApiPeliculas.Data;
using ApiPeliculas.Modelos;
using ApiPeliculas.Modelos.Dtos;
using ApiPeliculas.Repositorio.IRepositorio;
using System.Security.Cryptography;
using System.Text;

namespace ApiPeliculas.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ApplicationDbContext _bd;

        public UsuarioRepositorio(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public Usuario GetUsuario(int usuarioId)
        {
            return _bd.Usuario.FirstOrDefault(c=> c.Id == usuarioId);
        }

        public ICollection<Usuario> GetUsuarios()
        {
            return _bd.Usuario.OrderBy(c => c.Nombre).ToList();
        }

        public bool IsUniqueUsesr(string usuario)
        {
            var usuarioBd = _bd.Usuario.FirstOrDefault(u => u.NombreUsuario == usuario);
            if(usuarioBd == null)
            {
                return true;
            }
            return false;
        }

        public Task<UsuarioLoginRespuestaDto> Login(UsuarioLoginDto usuarioLoginDto)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> Registro(UsuarioRegistroDto usuarioRegistroDto)
        {
            var passwordEncriptado = obtenermd5(usuarioRegistroDto.Password);

            Usuario usuario = new Usuario()
            {
                NombreUsuario = usuarioRegistroDto.NombreUsuario,
                Password = passwordEncriptado,
                Nombre = usuarioRegistroDto.Nombre,
                Role = usuarioRegistroDto.Role
            };

            _bd.Usuario.Add(usuario);
            await _bd.SaveChangesAsync();
            usuario.Password = passwordEncriptado;
            return usuario;
        }

        //Metodo para encriptar la contraseña
        public static string obtenermd5(string valor)
        {
            using MD5 md5 = MD5.Create();

            byte[] data = Encoding.UTF8.GetBytes(valor);
            byte[] hash = md5.ComputeHash(data);

            string resp = "";
            for (int i = 0; i < hash.Length; i++)
                resp += hash[i].ToString("x2").ToLower();

            return resp;
        }
    }
}