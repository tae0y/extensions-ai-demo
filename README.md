# README
- `Extensions.AI.Templates`의 데모 레포입니다.

## Getting Started
- 이렇게 빌드합니다.
```
cd src
dotnet restore && dotnet build
dotnet watch run --project Aspire.AppHost/Aspire.AppHost.csproj
```

## 01. Extensions.AI.Templates 생성하기
- 폴더구조
```
- infra
- src
  - Extensions.AI.Templates
```

- 환경설정
```
dotnet new install Microsoft.Extensions.AI.Templates
dotnet new aichatweb # TODO: 폴더,파일명 이슈
cd <<your-project-directory>>
dotnet user-secrets set GitHubModels:Token YOUR-TOKEN
```

- 빌드/실행
```
dotnet run --project <<your-project-directory>>/extensions-ai-demo.csproj
```

![](./docs/screenshot-extensions-ai-demo.png)
- 내장된 PDF 기반으로 검색증강 채팅 데모

## 02. Aspire AppHost로 통합하기
- 환경설정
```
# aspire 템플릿 생성
dotnet new aspire # TODO: 폴더,파일명 이슈
dotnet sln solution.sln add Extensions.AI.Templates/extensions-ai-demo.csproj

# AppHost에 webchat 통함
cd Aspire.AppHost
dotnet add reference ../Extensions.AI.Templates

# ServiceDefaults 설정
cd Extensions.AI.Template
dotnet add reference ../Aspire.ServiceDefaults
```
- 환경설정후 AppHost 빌더에 Extensions.AI.Templates를 추가
- Extensions.AI.Templates에는 ServiceDefaults를 설정

- 빌드/실행
```
dotnet restore && dotnet build
dotnet watch run --project Aspire.AppHost/Aspire.AppHost.csproj
# TODO: aspire service discovery 이슈
```

![](./docs/screenshot-aspire-demo-resources.png)
![](./docs/screenshot-aspire-demo-tracking.png)
![](./docs/screenshot-aspire-demo-metric.png)
![](./docs/screenshot-aspire-demo-webchat.png)
- aspire에 통합해서 호스팅했고, 각종 메트릭을 수집하고 있다.
- [Service Defaults(세부내용 링크참조)](https://learn.microsoft.com/en-us/dotnet/aspire/fundamentals/service-defaults)를 통해 다음 디폴트 설정을 적용했다.
  - OpenTelemetry 메트릭 및 추적 구성 : 메트릭 수집 표준, 시각화/분석은 이 프로젝트에선 대시보드에서 수행함.
  - 기본 헬스체크 엔드포인트 추가 : 대시보드에서 앱의 가용상태를 확인할 수 있음. 헬스체크 주기/방식 조정 가능함.
  - 서비스 디스커버리 기능 : 앱 이름으로 다른 서비스를 참조가능, 도커 컴포즈에서 컨테이너명으로 참조하는 것과 유사함.


## TO BE CONTINUED ...
- Extensions.AI.Templates 세부설정, 기여할 이슈찾기
- Service Defaults 세부설정
- Github CI/CD Azure 배포 파이프라인
- Github CI/CD 린팅 구성
