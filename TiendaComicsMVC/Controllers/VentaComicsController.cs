using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaComicsMVC.Models;

namespace TiendaComicsMVC.Controllers
{
    //Esta Clase recibe la informacion de TiendaComicsMVCDAL para que se pueda crear una vista y visualizar la informacion
    public class VentaComicsController : Controller
    {
        TiendaComicsMVCDAL COMICS = new TiendaComicsMVCDAL();
        // GET: VentaComics
        public ActionResult Listar() /*Accion que recibe el metodo para mostrar toda la informacion de la base de datos*/
        {
            return View(COMICS.getAll());
        }

        public ActionResult Borrar(int id)/*Accion que recibe el metodo para eliminar un elemento*/
        {
            COMICS.Eliminar(id);
            return RedirectToAction("Listar");
        }

        public ActionResult Alta()/*Accion que recibe el metodo para agregar un nuevo elemento*/
        {
            return View();
        }

        [HttpPost]
        public ActionResult Alta(FormCollection F)/*Accion que almacena la nueva informacion de el metodo agregar nuevo y haga una redireccion a la lista para mostrar todo*/
        {
            Comic NuevoComic = new Comic()
            {
                id = Convert.ToInt32(F["id"]),
                numepisodio = Convert.ToInt32(F["numepisodio"]),
                nombre = F["nombre"],
                tipocomic = F["tipocomic"],
                costo = Convert.ToDouble(F["costo"]),
                editorial = F["editorial"],
                foto = F["foto"]
            };
            COMICS.Registrar(NuevoComic);
            return RedirectToAction("Listar");
        }

        public ActionResult Cambiar(int id)/*Accion que recibe el metodo actializar */
        {
            Comic Jbus = COMICS.getComic(id);
            return View(Jbus);
        }

        [HttpPost]
        public ActionResult Cambiar(FormCollection F)/*Accion que almacena la nueva informacion de el metodo actualizar y haga una redireccion a la lista para mostrar todo*/
        {
            Comic NuevoCom = new Comic()
            {
                id = Convert.ToInt32(F["id"]),
                numepisodio = Convert.ToInt32(F["numepisodio"]),
                nombre = F["nombre"],
                tipocomic = F["tipocomic"],
                costo = Convert.ToDouble(F["costo"]),
                editorial = F["editorial"],
                foto = F["foto"]
            };
            COMICS.Modificar(NuevoCom);
            return RedirectToAction("Listar");
        }

        public ActionResult PruebadeDiseño()/*AVista de el diseño con un estilo personalizado como una MasterPage*/
        {
            return View();
        }

        public ActionResult MarvelvsDc()/*Visualizar una pestaña con su contenido*/
        {
            return View();
        }

        public ActionResult DC()/*Visualizar una pestaña con su contenido*/
        {
            return View();
        }

        public ActionResult Marvel()/*Visualizar una pestaña con su contenido*/
        {
            return View();
        }
    }
}