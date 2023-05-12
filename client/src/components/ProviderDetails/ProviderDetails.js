import React from 'react';
import { useParams, useLocation, useNavigate } from 'react-router-dom';
import './ProviderDetails.css';

const ProviderDetails = () => {
  let { id } = useParams();
  let location = useLocation();
  let providerDetails = location.state ? location.state.providerDetails : null;
  let navigate = useNavigate();

  return (
    <div className="provider-details-container">
      <h1>Provider Detail Page</h1>
      <button onClick={() => navigate(-1)}>Back</button>
      {providerDetails ? (
        <div className="provider-details-content">
          <p>Provider ID: {id}</p>
          <h2>Basic Information</h2>
          <p>
            Name: {providerDetails.basic.firstName} {providerDetails.basic.lastName}
          </p>
          <p>Credential: {providerDetails.basic.credential}</p>
          <h2>Address</h2>
          {providerDetails.addresses.map((address, index) => (
            <div key={index}>
              <p>
                Address {index + 1}: {address.address1}, {address.city}, {address.state},{' '}
                {address.postalCode}
              </p>
            </div>
          ))}
        </div>
      ) : (
        <p>Provider details are not available.</p>
      )}
    </div>
  );
};

export default ProviderDetails;
