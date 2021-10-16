using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoJogos.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class IDController : ControllerBase
    {
        public readonly Singleton _Singleton1;
        public readonly Singleton _Singleton2;

        public readonly Scoped _Scoped1;
        public readonly Scoped _Scoped2;

        public readonly Transient _Transient1;
        public readonly Transient _Transient2;

        public IDController(Singleton Singleton1,
                                       Singleton Singleton2,
                                       Scoped Scoped1,
                                       Scoped Scoped2,
                                       Transient Transient1,
                                       Transient Transient2)
        {
            _Singleton1 = Singleton1;
            _Singleton2 = Singleton2;
            _Scoped1 = Scoped1;
            _Scoped2 = Scoped2;
            _Transient1 = Transient1;
            _Transient2 = Transient2;
        }

        [HttpGet]
        public Task<string> Get()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Singleton 1: {_Singleton1.Id}");
            stringBuilder.AppendLine($"Singleton 2: {_Singleton2.Id}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"Scoped 1: {_Scoped1.Id}");
            stringBuilder.AppendLine($"Scoped 2: {_Scoped2.Id}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"Transient 1: {_Transient1.Id}");
            stringBuilder.AppendLine($"Transient 2: {_Transient2.Id}");

            return Task.FromResult(stringBuilder.ToString());
        }

    }

    public interface Geral
    {
        public Guid Id { get; }
    }

    public interface Singleton :Geral
    { }

    public interface Scoped : Geral
    { }

    public interface Transient : Geral
    { }

    public class CicloVida : Singleton, Scoped, Transient
    {
        private readonly Guid _guid;

        public CicloVida()
        {
            _guid = Guid.NewGuid();
        }

        public Guid Id => _guid;
    }

}
