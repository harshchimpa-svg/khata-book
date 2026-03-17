using Application.Abouts.Dto;
using Application.CartItems.Dto;
using Application.Categories.Dto;
using Application.Contacts.Dto;
using Application.Customers.Dto;
using Application.DietDocuments.Dto;
using Application.Dites.Dto;
using Application.DiteTypes.Dto;
using Application.ExerciseDocuments.Dto;
using Application.Exercises.Dto;
using Application.GymDocuments.Dto;
using Application.GymProducts.Dto;
using Application.Gyms.Dto;
using Application.locations.Dto;
using Application.Memberships.Dto;
using Application.ProductDocuments.Dto;
using Application.SalePayments.Dto;
using Application.SaleProducts.Dto;
using Application.Sales.Dto;
using Application.ShopSettings.Dto;
using Application.Transactions.Dto;
using AutoMapper;
using Domain;

namespace Application.Common;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<CreateCartItemDto, CartItem>();
        CreateMap<CartItem, CartItemDto>();
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<CategoryDto, Category>();
        CreateMap<CreateContactDto, Contact>();
        CreateMap<Contact, ContactDto>();
        CreateMap<CreateDietDocumentDto, DietDocument>();
        CreateMap<DietDocument, DietDocumentDto>();
        CreateMap<CreateDietDto, Diet>();
        CreateMap<Diet, DietDto>();
        CreateMap<CreateDietTypeDto, DietType>();
        CreateMap<DietType, DietTypeDto>();
        CreateMap<CreateExerciseDocumentDto, ExerciseDocument>();
        CreateMap<ExerciseDocument, ExerciseDocumentDto>();
        CreateMap<CreateExerciseDto, Exercise>();
        CreateMap<Exercise, ExerciseDto>();
        CreateMap<CreateGymDocumentDto, GymDocument>();
        CreateMap<GymDocument, GymDocumentDto>();
        CreateMap<CreateGymProductDto, GymProduct>();
        CreateMap<GymProduct, GymProductDto>();
        CreateMap<CreateGymDto, Gym>();
        CreateMap<Gym, GymDto>();
        CreateMap<CreateAboutDto, About>();
        CreateMap<About, AboutDto>();
        CreateMap<CreateCustomerDto, Customer>();
        CreateMap<Customer, CustomerDto>();
        CreateMap<CreateShopSettingDto, ShopSetting>();
        CreateMap<ShopSetting, ShopSettingsDto>();
        CreateMap<CreateTransactionDto, Transaction>();
        CreateMap<Transaction, TransactionDto>();
        CreateMap<CreateLocationDto, Location>();
        CreateMap<Location, LocationDto>();
        CreateMap<CreateMembershipDto, Membership>();
        CreateMap<Membership, MembershipDto>();
        CreateMap<CreateProductDocumentDto, ProductDocument>();
        CreateMap<ProductDocument, ProductDocumentDto>();
        CreateMap<CreateSalePaymentDto, SalePayment>();
        CreateMap<SalePayment, SalePaymentDto>();
        CreateMap<CreateSaleProductDto, SaleProduct>();
        CreateMap<SaleProduct, SaleProductDto>();
        CreateMap<CreateSaleDto, Sale>();
        CreateMap<Sale, SaleDto>();
    }
}
