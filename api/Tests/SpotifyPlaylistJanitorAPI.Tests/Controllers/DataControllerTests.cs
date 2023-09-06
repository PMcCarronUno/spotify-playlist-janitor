﻿using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SpotifyPlaylistJanitorAPI.Controllers;
using SpotifyPlaylistJanitorAPI.Models.Database;
using SpotifyPlaylistJanitorAPI.Services.Interfaces;

namespace SpotifyPlaylistJanitorAPI.Tests.Controllers
{
    public class DataControllerTests : TestBase
    {
        private DataController _dataController;
        private Mock<IDatabaseService> _databaseServiceMock;

        public DataControllerTests()
        {
            _databaseServiceMock = new Mock<IDatabaseService>();

            _dataController = new DataController(_databaseServiceMock.Object);
        }

        [Test]
        public async Task DataController_GetMonitoredPlaylists_Returns_DatabasePlaylistModels()
        {
            // Arrange
            var databasePlaylists = Fixture.Build<DatabasePlaylistModel>().CreateMany().ToList();

            _databaseServiceMock
                .Setup(mock => mock.GetPlaylists())
                .ReturnsAsync(databasePlaylists);

            //Act
            var result = await _dataController.GetMonitoredPlaylists();

            // Assert
            result.Should().BeOfType<ActionResult<IEnumerable<DatabasePlaylistModel>>>();
            result?.Value?.Should().BeEquivalentTo(databasePlaylists);
        }

        [Test]
        public async Task DataController_GetMonitoredPlaylist_Returns_DatabasePlaylistModel()
        {
            // Arrange
            var databasePlaylist = Fixture.Build<DatabasePlaylistModel>().Create();

            _databaseServiceMock
                .Setup(mock => mock.GetPlaylist(It.IsAny<string>()))
                .ReturnsAsync(databasePlaylist);

            //Act
            var result = await _dataController.GetMonitoredPlaylist("testId");

            // Assert
            result.Should().BeOfType<ActionResult<DatabasePlaylistModel>>();
            result?.Value?.Should().BeEquivalentTo(databasePlaylist);
        }

        [Test]
        public async Task DataController_GetMonitoredPlaylist_Returns_Not_Found()
        {
            // Arrange
            DatabasePlaylistModel? databasePlaylist = null;
            var playlistId = Guid.NewGuid().ToString();

            _databaseServiceMock
                .Setup(mock => mock.GetPlaylist(It.IsAny<string>()))
                .ReturnsAsync(databasePlaylist);

            var expectedMessage = new { Message = $"Could not find playlist with id: {playlistId}" };

            //Act
            var result = await _dataController.GetMonitoredPlaylist(playlistId);

            // Assert
            var objResult = result.Result as NotFoundObjectResult;
            objResult?.Value.Should().BeEquivalentTo(expectedMessage);
        }

        [Test]
        public async Task DataController_CreateMonitoredPlaylist_Returns_DatabasePlaylistModel()
        {
            // Arrange
            var databaseRequest = Fixture.Build<DatabasePlaylistRequest>().Create();
            DatabasePlaylistModel? databasePlaylistNull = null;
            var databasePlaylist = Fixture.Build<DatabasePlaylistModel>().Create();

            _databaseServiceMock
                .Setup(mock => mock.GetPlaylist(It.IsAny<string>()))
                .ReturnsAsync(databasePlaylistNull);

            _databaseServiceMock
                .Setup(mock => mock.AddPlaylist(It.IsAny<DatabasePlaylistRequest>()))
                .ReturnsAsync(databasePlaylist);

            //Act
            var result = await _dataController.CreateMonitoredPlaylist(databaseRequest);

            // Assert
            result.Should().BeOfType<ActionResult<DatabasePlaylistModel>>();
            result?.Value?.Should().BeEquivalentTo(databasePlaylist);
        }

        [Test]
        public async Task DataController_CreateMonitoredPlaylist_Returns_Bad_Request()
        {
            // Arrange
            var databaseRequest = Fixture.Build<DatabasePlaylistRequest>().Create();
            var databasePlaylist = Fixture.Build<DatabasePlaylistModel>().Create();

            _databaseServiceMock
                .Setup(mock => mock.GetPlaylist(It.IsAny<string>()))
                .ReturnsAsync(databasePlaylist);

            var expectedMessage = new { Message = $"Playlist with id: {databaseRequest.Id} already exists" };

            //Act
            var result = await _dataController.CreateMonitoredPlaylist(databaseRequest);

            // Assert
            var objResult = result.Result as BadRequestObjectResult;
            objResult?.Value.Should().BeEquivalentTo(expectedMessage);
        }
    }
}
