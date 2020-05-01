# About RESTful API

- REST is an architectural style, it's **not** a standard;

- It **uses** standards to implement the architectural style;

- It is defined by 6 constraints (1 optional):

    1. **Uniform Interface**: API and consumers share one single, technical interface: URI, Method, Media Type (payload). This constraint has **4 subcontraints**:

        - *Identification of Resources*: A resource itself (`api/authors`) is conceptually separate from its representation, for instance, the representation media types such as `application/json`, `application/xml`, etc. That means that a resource can have multiple representations.

        - *Manipulation of Resources through Representations*: When a client holds representation of a resource, including any possible metadata, it should have enough information to modify or delete a resource on the server, provided it has permission to do so. That means that Representation + Metadata should be sufficient to modify or delete a resource. A proper way to do this is using **HATEOAS**, i.e., including metadata so the client knows what it can do with the resource.

        - *Self-descriptive Message*: Each message must include enough information to describe how to process the message, for instance, the request body using the `Accept` header and the response body using the `Content-Type` header. 

        - *Hypermedia As The Engine Of Application State (HATEOAS)*:
            
            - Hypermedia is a generalization of Hypertext (links)
            - It drives how to consume and use the API. It tells the consumer what it can do with the API
            - It allows for a self-documenting API
    
    1. **Client-Server**: Client and server are separated, that means they can evolve separately, without depending on neither knowing about each other.

    1. **Statelessness**: State is contained within the request. The necessary state to handle every request is contained within the request itself. The state is not kept on the server, but on the client.

    1. **Layered System**: A REST API can have multiple layers, but the client cannot tell what layer it's connected to.

    1. **Cacheable**: Each response message must explicitly state if it can be cached or not, for example, the response headers `Cache-Control`, `Expires`, `Last-Modified`, `ETag` and `Vary`.

    1. **Code on Demand (optional)**: Server can extend or customize client functionality, for example, the server transfering Javascipt code to the client to extend its functionality. This constraint applies more to web apps rather than web APIs.

- A system is only considered RESTful when it adheres to all the required constraints.
    
    - Most "RESTful" APIs aren't really RESTful. That doesn't make them bad APIs, as long as you understand the potential trade-offs.

- A method is considered **safe** when it doesn't change the resource representation, i.e, `GET`, `HEAD` and `OPTIONS`

- A method is considered **idempotent** when it can be called multiple times with the same result, i.e, `PUT` and `DELETE`

- `POST` method:

    - Unsafe
    - Not idempotent
    - 201 Created
    - Location header
- `PATCH` method:

    - Preferred over `PUT`
    - The request body should be sent with media type `application/json-patch+json`
    - Example:
    ```json
    [
        {
            "op": "replace",
            "path": "/title",
            "value": "new title"
        },
        {
           "op": "remove",
           "path": "/description" 
        }
    ]
    ```
    - Array of operations:
        - `op`: operation
        - `path`: path to the property
        - `value`: if given, it's the new value to apply to the property