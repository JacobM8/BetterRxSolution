import React, { useState } from 'react';
import axios from 'axios';
import './SearchPage.css';

const SearchPage = () => {
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [npiNumber, setNpiNumber] = useState("");
    const [taxonomyDescription, setTaxonomyDescription] = useState("");
    const [city, setCity] = useState("");
    const [state, setState] = useState("");
    const [zip, setZip] = useState("");
    const [searchResults, setSearchResults] = useState(null);
    const [searchClicked, setSearchClicked] = useState(false);

    const search = () => {
        let params = {
            firstName: firstName,
            lastName: lastName,
            npiNumber: npiNumber,
            taxonomyDescription: taxonomyDescription,
            city: city,
            state: state,
            zip: zip
        };

        // Filter out parameters that are empty
        params = Object.fromEntries(Object.entries(params).filter(([_, v]) => v != null && v !== ''));

        axios
            .get("https://localhost:7085/NpiRegistry", { params })
            .then(res => {
                setSearchResults(res.data.results); // updated this line
                setSearchClicked(true);
            })
            .catch(err => {
                console.error(err);
                setSearchClicked(true);
            });

    };

    console.log("searchResults: ", searchResults);
    if (searchResults !== null) {
        console.log("searchResults count: ", searchResults.length);
    } else {
        console.log("searchResults is null");
    }


    return (
        <div className="search-container">
            <h1>Search the NPI Registry</h1>
            <div className="search-form">
                <div className="search-row">
                    <input placeholder="First Name" onChange={e => setFirstName(e.target.value)} />
                    <input placeholder="Last Name" onChange={e => setLastName(e.target.value)} />
                </div>
                <div className="search-row">
                    <input placeholder="NPI Number" onChange={e => setNpiNumber(e.target.value)} />
                    <input placeholder="Taxonomy Description" onChange={e => setTaxonomyDescription(e.target.value)} />
                </div>
                <div className="search-row">
                    <input placeholder="City" onChange={e => setCity(e.target.value)} />
                    <input placeholder="State" onChange={e => setState(e.target.value)} />
                    <input placeholder="Zip" onChange={e => setZip(e.target.value)} />
                </div>
                <button type="button" onClick={search}>Search</button>
            </div>
            <div className="search-results">
                {searchClicked && !searchResults && <p>No results found, please try again.</p>}
                {searchResults && searchResults.length > 0 && (
                    <div>
                        {searchResults.map(result => (
                            <div key={result.number}>
                                {result.basic.firstName} {result.basic.lastName} {result.number}
                            </div>
                        ))}
                    </div>
                )}
            </div>
        </div>
    );
};

export default SearchPage;
