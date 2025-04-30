var builder = DistributedApplication.CreateBuilder(args);
builder.AddProject<Projects.extensions_ai_demo>("webchat"); // TODO: 다른 프로젝트 참조 이슈

builder.Build().Run();

