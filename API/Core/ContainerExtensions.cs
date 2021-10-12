using API.Jwt;
using Application;
using Application.Commands.Brands;
using Application.Commands.Categories;
using Application.Commands.Colors;
using Application.Commands.Comments;
using Application.Commands.Genders;
using Application.Commands.Groups;
using Application.Commands.Orders;
using Application.Commands.Products;
using Application.Commands.Ratings;
using Application.Commands.Seasons;
using Application.Commands.Sizes;
using Application.Commands.Users;
using Application.Queries;
using Application.Queries.Brands;
using EfDataAccess;
using Implementation.Commands.Brands;
using Implementation.Commands.Categories;
using Implementation.Commands.Colors;
using Implementation.Commands.Comments;
using Implementation.Commands.Genders;
using Implementation.Commands.Groups;
using Implementation.Commands.Orders;
using Implementation.Commands.Products;
using Implementation.Commands.Ratings;
using Implementation.Commands.Seasons;
using Implementation.Commands.Sizes;
using Implementation.Commands.Users;
using Implementation.Queries.Brands;
using Implementation.Queries.Categories;
using Implementation.Queries.Colors;
using Implementation.Queries.Genders;
using Implementation.Queries.Groups;
using Implementation.Queries.Orders;
using Implementation.Queries.Products;
using Implementation.Queries.Seasons;
using Implementation.Queries.Sizes;
using Implementation.Queries.UseCaseLogs;
using Implementation.Queries.Users;
using Implementation.Validators.Brand;
using Implementation.Validators.Category;
using Implementation.Validators.Color;
using Implementation.Validators.Comment;
using Implementation.Validators.Gender;
using Implementation.Validators.Group;
using Implementation.Validators.Order;
using Implementation.Validators.Product;
using Implementation.Validators.Rating;
using Implementation.Validators.Season;
using Implementation.Validators.Size;
using Implementation.Validators.User;
using Implementation.Validators.UserGroup;
using Implementation.Validators.UserUseCase;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Core
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<UseCaseExecutor>();
            //Brands
            services.AddTransient<ICreateBrandCommand, EfCreateBrandCommand>();
            services.AddTransient<IUpdateBrandCommand, EfUpdateBrandCommand>();
            services.AddTransient<IDeleteBrandCommand, EfDeleteBrandCommand>();
            services.AddTransient<IGetBrandsQuery, EfGetBrandsQuery>();
            //Categories
            services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
            services.AddTransient<IUpdateCategoryCommand, EfUpdateCategoryCommand>();
            services.AddTransient<IDeleteCategoryCommand, EfDeleteCategoryCommand>();
            services.AddTransient<IGetCategoryQuery, EfGetCategoriesQuery>();
            //Colors
            services.AddTransient<ICreateColorCommand, EfCreateColorCommand>();
            services.AddTransient<IUpdateColorCommand, EfUpdateColorCommand>();
            services.AddTransient<IDeleteColorCommand, EfDeleteColorCommand>();
            services.AddTransient<IGetColorQuery, EfGetColorsQuery>();
            //Gender
            services.AddTransient<ICreateGenderCommand, EfCreateGenderCommand>();
            services.AddTransient<IUpdateGenderCommand, EfUpdateGenderCommand>();
            services.AddTransient<IDeleteGenderCommand, EfDeleteGenderCommand>();
            services.AddTransient<IGetGendersQuery, EfGetGendersQuery>();
            //Sizes
            services.AddTransient<ICreateSizeCommand, EfCreateSizeCommand>();
            services.AddTransient<IUpdateSizeCommand, EfUpdateSizeCommand>();
            services.AddTransient<IDeleteSizeCommand, EfDeleteSizeCommand>();
            services.AddTransient<IGetSizeQuery, EfGetSizesQuery>();
            //Seasons
            services.AddTransient<ICreateSeasonCommand, EfCreateSeasonCommand>();
            services.AddTransient<IUpdateSeasonCommand, EfUpdateSeasonCommand>();
            services.AddTransient<IDeleteSeasonCommand, EfDeleteSeasonCommand>();
            services.AddTransient<IGetSeasonQuery, EfGetSeasonsQuery>();
            //Products
            services.AddTransient<ICreateProductCommand, EfCreateProductCommand>();
            services.AddTransient<IUpdateProductCommand, EfUpdateProductCommand>();
            services.AddTransient<IDeleteProductCommand, EfDeleteProductCommand>();
            services.AddTransient<IGetProductsQuery, EfGetProductsQuery>();
            services.AddTransient<IGetProductQuery, EfGetProductQuery>();
            //Groups
            services.AddTransient<ICreateGroupCommand, EfCreateGroupCommand>();
            services.AddTransient<IUpdateGroupCommand, EfUpdateGroupCommand>();
            services.AddTransient<IDeleteGroupCommand, EfDeleteGroupCommand>();
            services.AddTransient<IGetGroupQuery, EfGetGroupsQuery>();
            //UserUseCase
            services.AddTransient<ICreateUserUseCaseCommand, EfCreateUserUseCaseCommand>();
            services.AddTransient<IUpdateUserUseCaseCommand, EfUpdateUserUseCaseCommand>();
            services.AddTransient<IDeleteUserUseCaseCommand, EfDeleteUserUseCaseCommand>();
            services.AddTransient<IGetUseCaseQuery, EfGetUserUseCaseQuery>();
            //Users
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<IGetUserQuery, EfGetUserQuery>();
            services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            //User-Group
            services.AddTransient<ICreateUserGroupCommand, EfCreateUserGroupCommand>();
            services.AddTransient<IDeleteUserGroupCommand, EfDeleteUserGroupCommand>();
            //Orders
            services.AddTransient<ICreateOrderCommand, EfCreateOrderCommand>();
            services.AddTransient<IChangeOrderStatus, EfChangeOrderStatus>();
            services.AddTransient<IGetOrdersQuery, EfGetOrdersQuery>();
            services.AddTransient<IGetOrderQuery, EfGetOrderQuery>();
            //Use Case Logs
            services.AddTransient<IGetUseCaseLogQuery, EfGetUseCaseLogsQuery>();
            //Ratings
            services.AddTransient<ICreateRatingCommand, EfCreateRatingCommand>();
            //Comments
            services.AddTransient<ICreateCommentCommand, EfCreateCommentCommand>();
            services.AddTransient<IDeleteCommentCommand, EfDeleteCommentCommand>();
        }
        public static void AddValidators(this IServiceCollection services)
        {
            //brands
            services.AddTransient<CreateBrandValidator>();
            services.AddTransient<UpdateBrandValidator>();
            //categories
            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<UpdateCategoryValidator>();
            //colors
            services.AddTransient<CreateColorValidator>();
            services.AddTransient<UpdateColorValidator>();
            //gender
            services.AddTransient<CreateGenderValidator>();
            services.AddTransient<UpdateGenderValidator>();
            //sizes
            services.AddTransient<CreateSizeValidator>();
            services.AddTransient<UpdateSizeValidator>();
            //seasons
            services.AddTransient<CreateSeasonValidator>();
            services.AddTransient<UpdateSeasonValidator>();
            //products
            services.AddTransient<ProductValidator>();
            //Groups
            services.AddTransient<CreateGroupValidator>();
            services.AddTransient<UpdateGroupValidator>();
            //User
            services.AddTransient<UserRegistrationValidator>();
            services.AddTransient<UpdateUserValidator>();
            //User Use Case
            services.AddTransient<UserUseCaseValidator>();
            //User Group
            services.AddTransient<UserGroupValidator>();
            //Orders
            services.AddTransient<CreateOrderValidator>();
            //Ratings
            services.AddTransient<RatingValidator>();
            //Comments
            services.AddTransient<CommentValidator>();
        }
        public static void AddApplicationActor(this IServiceCollection services)
        {
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();

                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new AnonymousActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;

            });
        }
        public static void AddJwt(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddTransient<JwtManager>(x =>
            {
                var context = x.GetService<ShoeStoreContext>();

                return new JwtManager(context, appSettings.JwtIssuer, appSettings.JwtSecretKey);
            });

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = appSettings.JwtIssuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.JwtSecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
