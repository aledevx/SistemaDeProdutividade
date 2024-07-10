using SistemaDeProdutividade.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeProdutividade.Communication.ViewModel.Produtividades;
public record ProdutividadeFinalizadaIndexVM(Guid Id, 
                                            string Code,
                                            int Numero,
                                            string Cargo, 
                                            DateTime DataInicial, 
                                            DateTime DataFinal, 
                                            DateTime DataCriacao,
                                            StatusProdutividade Status);
