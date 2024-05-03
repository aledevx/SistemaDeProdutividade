﻿using SistemaDeProdutividade.Communication.Requests;
using SistemaDeProdutividade.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Domain.Contracts;
public interface ILogarUsuarioUseCase
{
    Task<UsuarioResponseJson> Execute(LoginRequestJson request);
}
