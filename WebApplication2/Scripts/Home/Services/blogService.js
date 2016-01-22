var blogService = function($http) {
    this.latest = function (callback) {

        return $http({
            method: "GET",
            url: "http://feeds.feedburner.com/UgidotnetLatestBlogPosts?format=xml"
        }).then(function (data) {

            console.log(data);

            var json = $.xml2json(data);

            var blogs = [];

            $.each(json.channel.item, function (i, item) {

                var article = {
                    permalink: item.link,
                    title: item.title,
                    author: item.creator,
                    date: item.pubDate
                };

                blogs[i] = article;
            });

            callback(blogs);
        }, function errorCallback(response) {
            console.log("error! " + JSON.stringify(response));
        });
    }
}