using System;

namespace ApiCatalogoJogos.Exceptions
{
    public class JogoNaoCadastradoException: Exception
    {
        public JogoNaoCadastradoException()
            :base("Jogo não cadastrado")
        {}
    }
}
