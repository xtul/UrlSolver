# UrlSolver

Don't get Rickrolled ever again.

UrlSolver is a tiny web service that enters user-provided link and retrieves the final destination URL and page title.


# Usage

### User Interface

Visit [https://url-solver.herokuapp.com/](https://url-solver.herokuapp.com/) to use a simple JS interface.

### Manual

Send a GET request to this url:

`https://url-solver.herokuapp.com/api?url=https://tiny.pl/h2xvk`

You should get this response:

```
{
	"url": "https://www.youtube.com/watch?v=dQw4w9WgXcQ",
	"title": "Rick Astley - Never Gonna Give You Up (Video) - YouTube",
	"notes": []
}
```

# Notice

UrlSolver works by following the `Location` HTTP header. If redirection is made in some other way (eg. JavaScript run on document load), UrlSolver will not detect it. But then again, do you really want to enter a masked URL that jumps through hoops to prevent being bypassed?