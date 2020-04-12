using Microsoft.AspNetCore.Mvc;
using PinguimStore.Dominio.Entidades;
using System;

namespace PinguimStore.WEB.Controllers
{
    [Route("api/[Controller]")]

    public class UsuarioController : Controller
    {

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpPost("VerificarUsuario")]
        public ActionResult VerificarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                if (usuario.Email == "pinguim25@gmail.com" && usuario.Senha == "123456")
                    return Ok(usuario);

                return BadRequest("Usuário incorreto ou senha inválida");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public ActionResult Post()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}

