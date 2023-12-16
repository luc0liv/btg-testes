using btg_testes_auto;
using btg_testes_auto.PlaylistSongs;
using FluentAssertions;
using NSubstitute;

namespace btg_test
{
    public class PlaylistSongsServiceTest
    {
        private readonly IPlaylistValidationService _mockPlaylistValidationService;
        PlaylistService _sut;

        public PlaylistSongsServiceTest()
        {
            _mockPlaylistValidationService = Substitute.For<IPlaylistValidationService>();
            _sut = new(_mockPlaylistValidationService);
        }

        [Fact]
        public void AddSongToPlaylist_ReturnsTrue()
        {
            Song song = new()
            {
                Title = "title",
                Artist = "Artist"
            };
            Song song2 = new()
            {
                Title = "title2",
                Artist = "Artist2"
            };
            Playlist playlist = new Playlist()
            {
                Songs = new List<Song>(),
                MaxSongs = 3,
            };

            playlist.Songs.Add(song);
            playlist.Songs.Add(song2);

            Song song3 = new()
            {
                Title = "title3",
                Artist = "Artist3"
            };

            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, song3)
                .Returns(true);

            bool result = _sut.AddSongToPlaylist(playlist, song3);
            result.Should().BeTrue();
            playlist.Songs.Should().NotBeEmpty();
            playlist.Songs.Should().Contain(song3);
        }

        [Fact]
        public void AddSongToPlaylist_ReturnsFalse()
        {
            Song song = new()
            {
                Title = "title",
                Artist = "Artist"
            };
            Song song2 = new()
            {
                Title = "title2",
                Artist = "Artist2"
            };
            Playlist playlist = new Playlist()
            {
                Songs = new List<Song>(),
                MaxSongs = 2,
            };

            playlist.Songs.Add(song);
            playlist.Songs.Add(song2);

            Song song3 = new()
            {
                Title = "title3",
                Artist = "Artist3"
            };

            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, song3)
                    .Returns(false);
            var result = _sut.AddSongToPlaylist(playlist, song3);
            result.Should().BeFalse();
            playlist.Songs.Should().NotContain(song3);
        }

        [Fact]
        public void AddSongsToPlaylist_PlaylistContainsSong()
        {
            Song song = new()
            {
                Title = "title",
                Artist = "Artist"
            };

            List<Song> songs = new List<Song>();
            Playlist playlist = new Playlist()
            {
                Songs = new List<Song>(),
                MaxSongs = 3,
            };

            songs.Add(song);

            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, song)
                .Returns(true);

            _sut.AddSongsToPlaylist(playlist, songs);
            playlist.Songs.Should().Contain(song);
        }
    }
}
