using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Communication.DTOs.Atividades;
public record AtividadePontuadaDTO(string Descricao, int Pontuacao, int Qtd);
