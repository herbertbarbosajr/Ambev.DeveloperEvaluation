using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Common.Security;

/// <summary>
/// Define o contrato para representação de um produto no sistema.
/// </summary>
public interface IProduct
{
    /// <summary>
    /// Obtém o identificador único do produto.
    /// </summary>
    /// <returns>O ID do produto como uma string.</returns>
    public string Id { get; }

    /// <summary>
    /// Obtém o nome de produto.
    /// </summary>
    /// <returns>O nome de produto.</returns>
    public string ProductName { get; }

}
