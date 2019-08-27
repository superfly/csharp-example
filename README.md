# Example c# app

## Getting Started

**1. Install the Fly CLI**

If you're on a Mac, you can install `flyctl` with Homebrew 

```bash
$ brew install superfly/tap/flyctl
```

For other systems, use the install script:
```bash
curl https://get.fly.io/flyctl.sh | sh
```

Checkout the docs for more ways to install [flyctl](https://github.com/superfly/flyctl#installation)

**2. Log In**

[Create a Fly account](https://fly.io/app/sign-up) if you haven't already signed up. Then login with:

```bash
$ flyctl auth login
```

**3. Clone the app**
```bash
$ git clone https://github.com/superfly/csharp-example.git
```

**4. Change into the example app directory**
```bash
$ cd csharp-example
```

## Deploy

**1. Create a new app**
```bash
$ flyctl apps create
```

**2. Deploy**
```bash
$ flyctl deploy
```

**3. Find app's IP address**

Each Fly app gets a unique IP address. You can view the IP address with:
```bash
$ flyctl info
```

**4. View your app**

Now it's time to see your app in action. Load the IP address in a browser or use curl:

```bash
$ curl http://<APP-IP>
```

## Add a Secret and View Deployment Status

**1. Set the Secret**

The example app says hello to whatever is in the `NAME` env variable, or `"World"` of not set. Let's change the name:

```bash
$ flyctl secrets set NAME=you
```

**2. View Deployment Status**

New VMs are stared each time your app changes. Once the new VMs are running the old ones are stopped. You can view the progress of a deployment and status about your app's VMs with the `status` command:

```bash
$ flyctl status
```

## View Logs

Everything your app writes to STDOUT and STDERR is visible in your app's logs:

```bash
$ flyctl logs
```
