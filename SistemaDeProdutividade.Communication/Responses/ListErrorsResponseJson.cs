﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Communication.Responses;
public record ListErrorsResponseJson(IList<string> Errors);
