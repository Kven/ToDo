using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using ToDo.Application.Features.Item;
using ToDo.Core.Entitys;
using ToDo.Core.Repository;

using Xunit;

namespace ToDo.Tests.Application.Features
{
    public class ItemTests
    {
        private readonly Mock<IRepository> _repository;

        public ItemTests()
        {
            _repository = new Mock<IRepository>();
            _repository.Setup(s => s.UpdateAsync(It.IsAny<string>(), It.IsAny<ItemEntity>())).Returns(Task.CompletedTask);
        }

        [Fact]
        public async void CompliteItemCommandItemNotFoundTest()
        {
            var emptyList = new List<ItemEntity>().AsQueryable();
            _repository.Setup(s => s.FindAsync(It.IsAny<Expression<Func<ItemEntity, bool>>>())).Returns(Task.FromResult(emptyList));

            var id = "someThing";
            var cmd = new CompliteItemCommand(id);
            var handler = new CompliteItemCommandHandler(_repository.Object);

            var result = await handler.Handle(cmd, new CancellationToken());
            Assert.NotEmpty(result.Error);
        }

        [Fact]
        public async void CompliteItemCommandItemAlreadyComplitedTest()
        {
            var complitedItem = new ItemEntity { Id = "complitedTest", Complited = true, CreateDate = DateTime.Now, Title = "Test title" };
            var list = new List<ItemEntity> { complitedItem }.AsQueryable();
            _repository.Setup(s => s.FindAsync(It.IsAny<Expression<Func<ItemEntity, bool>>>())).Returns(Task.FromResult(list));

            var id = "complitedTest";
            var cmd = new CompliteItemCommand(id);
            var handler = new CompliteItemCommandHandler(_repository.Object);

            var result = await handler.Handle(cmd, new CancellationToken());
            Assert.NotEmpty(result.Error);
        }

        [Fact]
        public async void CompliteItemCommandTest()
        {
            var item = new ItemEntity { Id = "test", Complited = false, CreateDate = DateTime.Now, Title = "Test title" };
            var list = new List<ItemEntity> { item }.AsQueryable();

            _repository.Setup(s => s.FindAsync(It.IsAny<Expression<Func<ItemEntity, bool>>>())).Returns(Task.FromResult(list));

            var id = "test";
            var cmd = new CompliteItemCommand(id);
            var handler = new CompliteItemCommandHandler(_repository.Object);

            var result = await handler.Handle(cmd, new CancellationToken());
            Assert.True(result.Success);
        }

        [Fact]
        public async void CreateItemCommandTest()
        {
            var title = "Title";
            var cmd = new CreateItemCommand(title);
            var handler = new CreateItemCommandHandler(_repository.Object);

            var result = await handler.Handle(cmd, new CancellationToken());
            Assert.NotNull(result.Item);
        }

        [Fact]
        public async void CreateItemsCommandTest()
        {
            var item = new CreateItemCommand("Title");
            var cmd = new CreateItemsCommand(item, item, item);
            var handler = new CreateItemsCommandHandler(_repository.Object);

            var result = await handler.Handle(cmd, new CancellationToken());
            Assert.Equal(3, result.Ids.Count());
        }

        [Fact]
        public async void DeleteItemCommand()
        {
            var id = "test";
            var cmd = new DeleteItemCommand(id);
            var handler = new DeleteItemCommandHandler(_repository.Object);

            var result = await handler.Handle(cmd, new CancellationToken());

            Assert.True(result.Success);
        }

        [Fact]
        public async void GetItemsQueryTest()
        {
            var item = new ItemEntity { Id = "test", Complited = false, CreateDate = DateTime.Now, Title = "Test title" };
            var item2 = new ItemEntity { Id = "test2", Complited = false, CreateDate = DateTime.Now, Title = "Test title" };
            var list = new List<ItemEntity> { item, item2 }.AsQueryable();

            _repository.Setup(s => s.GetAsync<ItemEntity>()).Returns(Task.FromResult(list));

            var cmd = new GetItemsQuery();
            var handler = new GetItemsQueryHandler(_repository.Object);
            var result = await handler.Handle(cmd, new CancellationToken());

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async void UpdateItemCommandTest()
        {
            var item = new ItemEntity { Id = "test", Complited = false, CreateDate = DateTime.Now, Title = "Test title" };

            var cmd = new UpdateItemCommand(item);
            var handler = new UpdateItemCommandHandler(_repository.Object);
            var result = await handler.Handle(cmd, new CancellationToken());

            Assert.True(result.Success);
        }
    }
}
