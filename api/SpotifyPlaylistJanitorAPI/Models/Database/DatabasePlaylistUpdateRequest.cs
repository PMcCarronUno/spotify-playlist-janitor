﻿using System.ComponentModel.DataAnnotations;

namespace SpotifyPlaylistJanitorAPI.Models.Database
{
    /// <summary>
    /// Model for creating database Playlist.
    /// </summary>
    public class DatabasePlaylistUpdateRequest
    {
        /// <summary>
        /// Skip threshold for playlist tracks in seconds.
        /// </summary>
        public int? SkipThreshold { get; set; }

        /// <summary>
        /// Ignore intial skips for playlist playback.
        /// </summary>
        public bool IgnoreInitialSkips { get; set; }

        /// <summary>
        /// Auto track-cleanup limit for playlist tracks.
        /// </summary>
        public int? AutoCleanupLimit { get; set; }
    }
}
