# CQRScomMediator

Assistindo do Vídeo do André Baltieri e assimilando o conceito, criei duas soluções:

1) A primeira implementa do CQRS sem o MediatR
2) A segunda implementa o CQRS com o MediatR

A versão do .NET é a 3.1 e como o vídeo é de 2020, o comando no setup:

 public void ConfigureServices(IServiceCollection services)
 {
     services.AddMediatR(Assembly.GetExecutingAssembly());
 }
 
 não funciona.
 
 Como o MediatR está em outro Assembly, já que temos 3 projetos na mesma solução, o comando aplicado para funcionar a solução foi:
 
 
public void ConfigureServices(IServiceCollection services)
{
    // Precisamos informar qual assembly está o MediatR
    var assembly = AppDomain.CurrentDomain.Load("Shop.Domain");
    services.AddMediatR(assembly);
}

Nessa solução temos, também, o Swagger configurado.
 
 
