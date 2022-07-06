using Portafolio.Models;

namespace Portafolio.Servicios
{
    public interface IRepositorioProyectos
    {
        List<ProyectoViewModel> ObtenerProyecto();
    }

    public class RepositorioProyectos : IRepositorioProyectos
    {
        public List<ProyectoViewModel> ObtenerProyecto()
        {
            return new List<ProyectoViewModel>() { new ProyectoViewModel
                {
                    Titulo = "Amazon",
                    Descripcion = "E-Comerce realizado en ASP.NET Core",
                    Link="https://amazon.com",
                    ImagenUrl="/imagenes/amazon.png"
                },
                new ProyectoViewModel
                 {
                    Titulo = "New York Times",
                    Descripcion = "Página de noticias en Vue.js",
                    Link="https://nytimes.com",
                    ImagenUrl="/imagenes/nyt.png"
                },
                 new ProyectoViewModel
                  {
                    Titulo = "Reddit",
                    Descripcion = "Red social para compartir en comunidades",
                    Link="https://reddit.com",
                    ImagenUrl="/imagenes/reddit.png"
                },
                  new ProyectoViewModel
                   {
                    Titulo = "Steam",
                    Descripcion = "Tienda en linea para comprar videojuegos",
                    Link="https://store.steampowered.com",
                    ImagenUrl="/imagenes/steam.png"
                }
            };
        }
    }
}
