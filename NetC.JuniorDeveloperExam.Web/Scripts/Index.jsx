class BlogPosts extends React.Component {
    render() {
        return (
            <div class="Container">
                <BlogPost data="{this.}"/>
            </div>
        );
    }
}


class InputComment extends React.Component {
    render() {
        return (
            <div class="card my-4">
                <h5 class="card-header">Leave a Comment:</h5>
                <div class="card-body">
                    <form>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label for="Name">Name</label>
                                <input type="email" class="form-control" id="Name" placeholder="Name"/>
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="EmailAddress">Email Address</label>
                                    <input type="password" class="form-control" id="EmailAddress" placeholder="Email Address"/>
                                </div>
                                </div>

                                <div class="form-group">
                                    <label for="Message">Message</label>
                                    <textarea id="Message" class="form-control" rows="3"></textarea>
                                </div>
                                <button type="submit" class="btn btn-primary">Submit</button>
                        </form>
                        </div>
                </div>
            )
    }
}

class Comments extends React.Component {
    render() {
        return (
            <div class="media mb-4">
                <img class="d-flex mr-3 rounded-circle user-avatar" src="https://eu.ui-avatars.com/api/?name=Steven+Barker" alt="Steven Barker"/>
                    <div class="media-body">
                        <h5 class="mt-0">Steven Barker <small><em>(November 11, 2019 - 20:44)</em></small></h5>
                        Sed vel odio consequat, elementum massa quis, lobortis est. Nulla egestas congue dolor, sit amet fermentum massa dignissim sit amet. In vestibulum iaculis egestas.
                    </div>
                </div>
            )
    }
}

class BlogPost extends React.Component {
    render() {
        return (
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="mt-4">{this.props.title}</h1>
                        <hr/>
                        {/*    <p>Posted on @Model.Date.ToString("MMMM") @Model.Date.Day, @Model.Date.Year</p>*/}
                        <hr/>
                        {/*    <img class="img-fluid rounded" src="@Model.Image" alt="Top 5 Considerations for a Content-First Design Approach"/>*/}
                        <hr/>
                    </div>
                </div>
            </div>
        );
    }
    }
                                            

ReactDOM.render(<BlogPosts url='/BlogPost'/>, document.getElementById('content'));