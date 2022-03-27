# Hello, Personalize!

This is the code project for the [Hello, Personalize!](https://davidpallmann.hashnode.dev/hello-personalize) blog post. 

This episode: Amazon Personalize. In this Hello, Cloud blog series, we're covering the basics of AWS cloud services for newcomers who are .NET developers. If you love C# but are new to AWS, or to this particular service, this should give you a jumpstart.

In this post we'll introduce Amazon Personalize and use it in a "Hello, Cloud" .NET program to make personalized product recommendations. We'll do this step-by-step, making no assumptions other than familiarity with C# and Visual Studio. We're using Visual Studio 2022 and .NET 6.

## Our Hello, Personalize Project

We will configure Personalize for personalized movie recommendations. We'll be spending time in the AWS console uploading data to S3, creating artifacts in Amazon Personalize, training a model with the data, and deploying a campaign. After that we'll call Personalize from .NET code to get personalized movie recommendations based on user Id. We'll also report user movie watch events to Amazon Personalize to show how the interaction data can be kept up to date with new user activity in real-time. 
See the blog post for the tutorial to create this project and run it on AWS.
