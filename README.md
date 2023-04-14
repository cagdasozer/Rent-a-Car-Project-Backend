Rent a Car Project - Çağdaş Özer   <br>

<br>
<h2> <a href="https://github.com/cagdasozer">Read Me :) Daha Fazla</a>
 </h2>
<br>

<h3> 
 - Bu proje SOLID prensiplerine uygun bir şekilde, eğitim tekrarı niteliğinde hazırlanmıştır.<br>
 - Proje Aspect'ler (Validation[FluentValidation], Transaction, Cache, Performance) barındırmaktadır.<br>
 - JWT entegre edilmiştir ve Autofac desteği kullanılmıştır. <br>
</h3>
<br>
ReCap Project : Araba Kiralama Sistemi
Rent A Car

⭐ Introduction
Entities, DataAccess, Business, Core ve WebAPI katmanlarından oluşan araba kiralama projesidir. Bu projede Katmanlı mimari yapısı ve SOLID prensiplerine dikkate alınarak yazılmıştır. JWT entegrasyonu; Transaction, Cache, Validation ve Performance aspect'lerinin implementasyonu gerçekleştirilmiştir.
Validation için FluentValidation desteği, IoC için ise Autofac desteği eklenmiştir.
Sql query dosyamı da ekledim isteyen varsa faydalanabilir.
Recent Changes
✔ Caching, Transaction ve Performance aspectleri eklendi.
✔ CarManager class'ına ait olan GetAll metoduna Logging aspect'i eklendi.
✔ Car nesnesinin GetAll metodu performance ile test edildi.
✔ Çalıştırılan metodlar log4net.config ile log.json dosyasına yazıldı.

Table of Contents
Recent Changes
Installation
Usage
Layers
SQL Query
Tables in Database
Output
Files
License
Installation 
# Clone to repository
$ git clone https://github.com/cagdasozer/Rent-a-Car-Project-Backend.git

# Install dependencies
$ dotnet restore
Usage
Aşağıda görmüş olduğunuz resimdeki işlemi gerçekleştirdikten sonra Ctrl+F5 ile uygulamayı çalıştırabilirsiniz. Daha sonrasında Postman uygulaması aracılığıyla projeye isteklerde bulunabilirsiniz.

Image for Usage

Layers
🗃 Entities Layer
    📂 Concrete
         📃 Brand.cs
         📃 Car.cs
         📃 CarImage.cs
         📃 Color.cs
         📃 CreditCard.cs
         📃 Customer.cs
         📃 FindeksScore.cs
         📃 Payment.cs
         📃 Rental.cs
         
    📂 DTOs
         📃 CarDetailDto.cs
         📃 CarFilter.cs
         📃 CustomerDetailDto.cs
         📃 CustomerUpdateDto.cs
         📃 RentalDetailDto.cs
         📃 UserForLoginDto.cs
         📃 UserForRegisterDto.cs
         📃 UserUpdateDto.cs


🗃 Business Layer

     📂 Abstract
         📃 IAuthService.cs
         📃 IBrandService.cs
         📃 ICarImageService.cs
         📃 ICarService.cs
         📃 IClaimService.cs
         📃 IColorService.cs
         📃 ICreditCardService.cs
         📃 ICustomerService.cs
         📃 IFindeksScoreService.cs
         📃 IPaymentService.cs
         📃 IRentalService.cs
         📃 IUserService.cs
         
    📂 BusinessAspect
        📂 Autofac
             📃 SecuredOperation.cs
             
    📂 Concrete
         📃 AuthManager.cs
         📃 BrandManager.cs
         📃 CarImageManager.cs
         📃 CarManager.cs
         📃 ClaimManager.cs
         📃 ColorManager.cs
         📃 CreditCardManager.cs
         📃 CustomerManager.cs
         📃 FindeksScoreManager.cs
         📃 PaymentManager.cs
         📃 RentalManager.cs
         📃 UserManager.cs
         
     📂 Constants
         📃 Messages.cs
         
     📂 DependencyResolvers
         📂 Autofac
             📃 AutofacBusinessModule.cs
             
     📂 ValidationRules
         📂 FluentValidation
             📃 BrandValidator.cs
             📃 CarImageValidator.cs
             📃 CarValidator.cs
             📃 ColorValidator.cs
             📃 CustomerValidator.cs
             📃 RentalValidator.cs
             📃 UserValidator.cs


🗃 Data Access Layer

    📂 Abstract
         📃 IBrandDal.cs
         📃 ICarDal.cs
         📃 ICarImageDal.cs
         📃 IClaimDal.cs
         📃 IColorDal.cs
         📃 ICreditCardDal.cs
         📃 ICustomerDal.cs
         📃 IFindeksScoreDal.cs
         📃 IPaymentDal.cs
         📃 IRentalDal.cs
         📃 IUserDal.cs
         
     📂 Concrete
             📂 EntityFramework
                 📃 EfBrandDal.cs
                 📃 EfCarDal.cs
                 📃 EfCarImageDal.cs
                 📃 EfClaimDal.cs
                 📃 EfColorDal.cs
                 📃 EfCreditCardDal.cs
                 📃 EfCustomerDal.cs
                 📃 EfFindeksScoreDal.cs
                 📃 EfPaymentDal.cs
                 📃 EfRentalDal.cs
                 📃 EfUserDal.cs
                 📃 ReCarContext.cs


🗃 Core Layer
    📂 Aspect
        📂 Autofac
            📂 Caching
                 📃 CacheAspect.cs
                 📃 CacheRemoveAspect.cs
            📂 Performance
                 📃 PerformanceAspect.cs
            📂 Transaction
                 📃 TransactionScopeAscpect.cs
            📂 Validation
                 📃 ValidationAspect.cs
                 
    📂 CrossCuttingConcerns
        📂 Caching
          📂 Microsoft
                📃 MemoryCacheManager.cs
           📃 ICacheManager.cs
         📂 Validation
            📃 ValidationTool.cs   
            
    📂 DataAccess
      📂 EntityFramework
             📃 EfEntityRepositoryBase.cs
         📃 IEntityRepository.cs
         
    📂 DependencyResolvers
         📃 CoreModule.cs
         
    📂 Entities
        📂 Abstract
            📃 IDto.cs
            📃 IEntity.cs
        📂 Concrete
             📃 OperationClaim.cs
             📃 User.cs
             📃 UserOperationClaim.cs
             
    📂 Extensions
         📃 ClaimExtensions.cs
         📃 ClaimsPrincipalExtensions.cs
         📃 ErrorDetails.cs
         📃 ExceptionMiddleware.cs
         📃 ExceptionMiddlewareExtensions.cs
         📃 ServiceCollectionExtensions.cs
         
    📂 Utilities
        📂 Business
             📃 BusinessRules.cs
        📂 Helpers
          📂 FileHelper
             📃 FileHelper.cs
             📃 IFileHelper.cs
             
        📂 Interceptors
             📃 AspectInterceptorSelector.cs
             📃 MethodInterception.cs
             📃 MethodInterceptionBaseAttribute.cs
             
        📂 IoC
             📃 ICoreModule.cs
             📃 ServiceTool.cs
             
        📂 Messages
             📃 AspectMessages.cs
             
        📂 Results
             📃 IDataResult.cs
             📃 DataResult.cs
             📃 SuccessDataResult.cs
             📃 ErrorDataResult.cs
             📃 IResult.cs
             📃 Result.cs
             📃 SuccessResult.cs
             📃 ErrorResult.cs
             
        📂 Security
            📂 Encryption
                 📃 SecurityKeyHelper.cs
                 📃 SigningCredentialsHelper.cs
            📂 Hashing
                 📃 HashingHelper.cs
            📂 JWT
                 📃 AccessToken.cs
                 📃 ITokenHelper.cs
                 📃 JwtHelper.cs
                 📃 TokenOptions.cs


🗃 Presentation Layer
     📃 Program.cs


🗃 WebAPI Layer
    📃 Startup.cs
    📂 Controllers
         📃 AuthController.cs
         📃 BrandsController.cs
         📃 CarImagesController.cs
         📃 CarsController.cs
         📃 ColorsController.cs
         📃 CreditCardsController.cs
         📃 CustomersController.cs
         📃 FindeksScoresController.cs
         📃 PaymentsController.cs
         📃 RentalsController.cs
         📃 UsersController.cs
