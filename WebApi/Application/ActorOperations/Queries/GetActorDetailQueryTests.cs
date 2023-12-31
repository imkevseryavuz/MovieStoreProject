﻿using AutoMapper;
using FluentAssertions;
using MovieStoreFinal.Application.ActorOperations.Queries.GetActorDetail;
using MovieStoreFinal.DbOperations;
using System;
using System.Linq;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Application.GenreOperations.Queries
{
    public class GetActorDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;


        public GetActorDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper =testFixture.Mapper;

        }

        [Fact]
        public void WhenGivenActorIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetActorDetailQuery command = new GetActorDetailQuery(_context,_mapper);
            command.ActorId = 0;


            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>()
            .And.Message.Should().Be("Aranılan oyuncu bulunamadı.");
        }

        [Fact]
        public void WhenGivenActorIdIsinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetActorDetailQuery command = new GetActorDetailQuery(_context,_mapper);
            command.ActorId = 1;


            FluentActions.Invoking(() => command.Handle()).Invoke();

            var actor = _context.Actors.SingleOrDefault(actor => actor.Id == command.ActorId);
            actor.Should().NotBeNull();
        }
    }
}
