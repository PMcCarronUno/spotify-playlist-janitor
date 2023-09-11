﻿using SpotifyPlaylistJanitorAPI.Models.Database;
using Swashbuckle.AspNetCore.Filters;
using System.Diagnostics.CodeAnalysis;

namespace SpotifyPlaylistJanitorAPI.SwaggerExamples.Database
{
    /// <summary>
    /// Swagger example.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class DatabaseSkippedTrackModelExample : IExamplesProvider<IEnumerable<DatabaseSkippedTrackResponse>>
    {
        /// <summary>
        /// Implementation of Swashbuckle GetExamples() IExamplesProvider method.
        /// </summary>
        /// <returns>Example <see cref="IEnumerable{T}"/> of type <see cref="DatabasePlaylistModel"/>.</returns>
        public IEnumerable<DatabaseSkippedTrackResponse> GetExamples()
        {
            return new List<DatabaseSkippedTrackResponse> 
            {
                //new DatabaseSkippedTrackModel
                //{
                //    TrackId = "track_id_1",
                //    PlaylistId = "playlist_id",
                //    SkippedDate = new DateTime(),   
                //},
                //new DatabaseSkippedTrackModel
                //{
                //    TrackId = "track_id_2",
                //    PlaylistId = "playlist_id",
                //    SkippedDate = new DateTime(),   
                //},
                //new DatabaseSkippedTrackModel
                //{
                //    TrackId = "track_id_3",
                //    PlaylistId = "playlist_id",
                //    SkippedDate = new DateTime(),   
                //},
                //new DatabaseSkippedTrackModel
                //{
                //    TrackId = "track_id_4",
                //    PlaylistId = "playlist_id",
                //    SkippedDate = new DateTime(),   
                //},
            };
        }
    }
}
