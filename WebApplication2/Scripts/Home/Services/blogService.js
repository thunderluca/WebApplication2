var blogService = function($http) {
    this.latest = function (callback) {

        return $http({
            method: "get",
            url: "http://feeds.feedburner.com/UgidotnetLatestBlogPosts?format=xml"
        }).success(function (data) {

            var json = $.xml2json(data);

            var blogs = [];

            $.each(json.channel.item, function (i, item) {

                var article = {
                    id: i,
                    permalink: item.link,
                    title: item.title,
                    author: item.creator,
                    date: item.pubDate
                };

                console.log(JSON.stringify(article));

                blogs[i] = article;
            });

            callback(blogs);
        });
    }
}