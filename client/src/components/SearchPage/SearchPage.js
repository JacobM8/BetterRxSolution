import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
import './SearchPage.css';

const SearchPage = () => {
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [npiNumber, setNpiNumber] = useState("");
    const [taxonomyDescription, setTaxonomyDescription] = useState("");
    const [city, setCity] = useState("");
    const [state, setState] = useState("");
    const [zip, setZip] = useState("");
    const [searchClicked, setSearchClicked] = useState(false);

    const [searchResults, setSearchResults] = useState(() => {
        const savedResults = sessionStorage.getItem('searchResults');
        return savedResults ? JSON.parse(savedResults) : null;
    });

    useEffect(() => {
        sessionStorage.setItem('searchResults', JSON.stringify(searchResults));
    }, [searchResults]);

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

        params = Object.fromEntries(Object.entries(params).filter(([_, v]) => v != null && v !== ''));

        axios
            .get("https://localhost:7085/NpiRegistry", { params })
            .then(res => {
                const transformedResults = res.data.results.map(result => ({
                    number: result.number,
                    basic: result.basic,
                    addresses: result.addresses,
                    createdEpoch: result.createdEpoch,
                    enumerationType: result.enumerationType,
                    lastUpdatedEpoch: result.lastUpdatedEpoch,
                    practiceLocations: result.practiceLocations
                }));

                setSearchResults(transformedResults);
                setSearchClicked(true);
            })
            .catch(err => {
                console.log("error: ", err);
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

    const searchResultsList = searchResults.map(result => (
        <div key={result.number}>
            <Link to={{
                pathname: `/provider/${result.number}`,
                state: { providerDetails: result }
            }}>
                {result.basic.firstName} {result.basic.lastName}
            </Link>
        </div>
    ));

    console.log("searchResultList: ", searchResultsList);

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
                                <Link to={{
                                    pathname: `/provider/${result.number}`,
                                    state: { providerDetails: result }
                                }}>
                                    {result.basic.firstName} {result.basic.lastName}
                                </Link>
                            </div>
                        ))}
                    </div>
                )}
            </div>
        </div>
    );
};

export default SearchPage;
