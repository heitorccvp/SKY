using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SKY.Domain.Interfaces;
using SKY.Domain.Models;
using System;

namespace SKY.Application.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[AllowAnonymous]
	public class UsuarioController : ControllerBase
	{
		private readonly IUsuarioService _usuarioService;

		public UsuarioController(IUsuarioService usuarioService)
		{
			_usuarioService = usuarioService;
		}

		[HttpPost("SignUp")]
		public IActionResult SignUp([FromBody] InserirUsuarioModel usuario)
		{
			try
			{
				var usuarioGerado = _usuarioService.Inserir(usuario);
				return Ok(usuarioGerado);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("SignIn")]
		public IActionResult SignIn([FromBody] UsuarioSingInModel usuario)
		{
			try
			{
				var usuarioLogado = _usuarioService.Logar(usuario);

				return Ok(usuarioLogado);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("BuscarUsuario")]
		[Authorize(Roles ="Usuario")]
		public IActionResult BuscarUsuario([FromBody] BuscarUsuarioModel usuario)
		{
			try
			{
				var usuarioLogado = _usuarioService.BuscarUsuario(usuario.id);

				return Ok(usuarioLogado);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}


	}
}
