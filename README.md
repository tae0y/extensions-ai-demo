# README
- `Extensions.AI.Templates`의 데모 레포입니다.

## Getting Started
- 폴더구조
```
- infra
- src
  - Extensions.AI.Templates
```

- 환경설정
```
dotnet new install Microsoft.Extensions.AI.Templates
dotnet new aichatweb
cd <<your-project-directory>>
dotnet user-secrets set GitHubModels:Token YOUR-TOKEN
```

- 빌드/실행
```
dotnet run --project <<your-project-directory>>/extensions-ai-demo.csproj
```

![](./docs/screenshot-extensions-ai-demo.png)
- 내장된 PDF 기반으로 검색증강 채팅 데모
