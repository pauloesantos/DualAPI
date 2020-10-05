using System;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace DualApi.Test
{
    [CollectionDefinition("Integration Tests")]
    public class TestCollection : ICollectionFixture<WebApplicationFactory<DualAPI.Startup>>
    {

    }
}