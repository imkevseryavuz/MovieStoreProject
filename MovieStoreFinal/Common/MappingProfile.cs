using AutoMapper;
using MovieStoreFinal.Entities;
using MovieStoreFinal.Application.GenreOperations.Queries.GetGenreDetail;
using MovieStoreFinal.Application.GenreOperations.Queries.GetGenres;
using MovieStoreFinal.Application.GenreOperations.Commands.CreateGenre;
using MovieStoreFinal.Application.GenreOperations.Commands.UpdateGenre;
using MovieStoreFinal.Application.CustomerOperations.Command.CreateCustomer;
using MovieStoreFinal.Application.CustomerOperations.Queries;
using MovieStoreFinal.Application.DirectorOperations.Commands.CreateDirector;
using MovieStoreFinal.Application.DirectorOperations.Commands.UpdateDirector;
using MovieStoreFinal.Application.DirectorOperations.Queries.GetDirectorDetail;
using MovieStoreFinal.Application.DirectorOperations.Queries.GetDirectors;
using MovieStoreFinal.Application.ActorOperations.Commands.CreateActor;
using MovieStoreFinal.Application.ActorOperations.Commands.UpdateActor;
using MovieStoreFinal.Application.ActorOperations.Queries.GetActorDetail;
using MovieStoreFinal.Application.ActorOperations.Queries.GetActors;
using MovieStoreFinal.Application.MovieOperations.Commands.CreateMovie;
using MovieStoreFinal.Application.MovieOperations.Commands.UpdateMovie;
using MovieStoreFinal.Application.MovieOperations.Queries.GetMovieDetail;
using MovieStoreFinal.Application.MovieOperations.Queries.GetMovies;
using MovieStoreFinal.Application.OrderOperations.Queries.GetOrders;
using MovieStoreFinal.Application.OrderOperations.Queries.GetDetailOrder;
using MovieStoreFinal.Application.OrderOperations.Commands.CreateOrder;
using MovieStoreFinal.Application.OrderOperations.Commands.UpdateOrder;
using System.Linq;

namespace MovieStore.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Genre
            CreateMap<CreateGenreViewModel, Genre>();
            CreateMap<Genre, GenreViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<UpdateGenreViewModel, Genre>();

            //Customer
            CreateMap<CreateCustomerModel, Customer>();
            CreateMap<Customer, CustomerViewModel>();

            //Director
            CreateMap<CreateDirectorViewModel, Director>();
            CreateMap<UpdateDirectorViewModel, Director>();
            CreateMap<Director, DirectorDetailViewModel>();
            CreateMap<Director, DirectorViewModel>();

            //Actor
            CreateMap<CreateActorViewModel, Actor>();
            CreateMap<UpdateActorViewModel, Actor>();
            CreateMap<Actor, ActorDetailViewModel>();
            CreateMap<Actor, ActorViewModel>();

            //Movie
            CreateMap<CreateMovieViewModel, Movie>();
            CreateMap<UpdateMovieViewModel, Movie>();

            CreateMap<Movie, MovieDetailViewModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.GenreName))
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.FirstName))
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.LastName))
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.MovieActor.Select(p => p.Actor).ToList()));

            CreateMap<Movie, MovieViewModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.GenreName))
                .ForMember(dest => dest.DirectorFirstName, opt => opt.MapFrom(src => src.Director.FirstName))
                .ForMember(dest => dest.DirectorLastName, opt => opt.MapFrom(src => src.Director.LastName))
                .ForMember(dest => dest.Actor, opt => opt.MapFrom(src => src.MovieActor.Select(p => p.Actor).ToList()));


            //Order
            CreateMap<Order, OrderViewModel>()
               .ForMember(dest => dest.CustomerFirstName, opt => opt.MapFrom(src => src.Customer.Name))
               .ForMember(dest => dest.CustomerLastName, opt => opt.MapFrom(src => src.Customer.Surname))
               .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Movie.MovieName))
               .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Movie.Price));
            CreateMap<Order, OrderDetailViewModel>()
               .ForMember(dest => dest.CustomerFirstName, opt => opt.MapFrom(src => src.Customer.Name))
               .ForMember(dest => dest.CustomerLastName, opt => opt.MapFrom(src => src.Customer.Surname))
               .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Movie.MovieName))
               .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Movie.Price));
            CreateMap<CreateOrderViewModel, Order>();
            CreateMap<UpdateOrderViewModel, Order>();



        }


    }
}
