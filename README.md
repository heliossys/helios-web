# Helios Systems Website

Corporate website for Helios Systems, built with [BlazorStatic](https://github.com/tesar-tech/BlazorStatic).

## Development

```bash
dotnet run
```

The site runs at `https://localhost:5001` during development.

## Build

```bash
dotnet run
```

Static files are generated to the `output/` directory.

## Deployment

The site is deployed via Docker. Build the image:

```bash
docker build -t helios-web .
```

Run with nginx:

```bash
docker run -p 80:80 helios-web
```

## Configuration

- **Google Analytics**: Update the GA4 measurement ID in `Components/App.razor`
- **Contact Form**: Configure your Formspree form ID in `Components/Pages/Contact.razor`
- **Site Constants**: Edit `WebsiteKeys` in `Program.cs`
