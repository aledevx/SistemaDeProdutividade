namespace SistemaDeProdutividade.Application.Services.Formatador;
public class FormatadorService
{
    public string CapitalizarNome(string nome)
    {
        string[] excecoes = new string[] { "e", "de", "da", "das", "do", "dos" };
        var palavras = new Queue<string>();
        foreach (var palavra in nome.Split(' '))
        {
            if (!string.IsNullOrEmpty(palavra))
            {
                var emMinusculo = palavra.ToLower();
                var letras = emMinusculo.ToCharArray();
                if (!excecoes.Contains(emMinusculo)) letras[0] = char.ToUpper(letras[0]);
                palavras.Enqueue(new string(letras));
            }
        }
        return string.Join(" ", palavras);
    }
}
